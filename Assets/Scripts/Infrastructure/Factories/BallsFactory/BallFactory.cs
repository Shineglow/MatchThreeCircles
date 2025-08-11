using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Infrastructure.AssetManagement;
using Infrastructure.ObjectsPool;
using StaticData.BallsStaticData;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Infrastructure.Factories.BallsFactory
{
	public class BallFactory : IBallFactory
	{
		private readonly IAssetProvider _assetProvider;
		private readonly IBallsStaticData _ballsStaticData;
		private readonly Stack<ObjectDisableListener> _freeObjects = new Stack<ObjectDisableListener>();

		public BallFactory(IAssetProvider assetProvider, IBallsStaticData ballsStaticData)
		{
			_assetProvider = assetProvider;
			_ballsStaticData = ballsStaticData;
			WarmUp();
		}
		
		public async UniTask<GameObject> GetRandomBall()
		{
			IReadOnlyBallData randomBallData = _ballsStaticData.Balls[Random.Range(0, _ballsStaticData.Balls.Count)];

			return await GetBallGeneral(randomBallData);
		}

		public async UniTask<GameObject> GetBall(EBallId ballId)
		{
			IReadOnlyBallData randomBallData = GetAssociatedData(ballId);
			
			return await GetBallGeneral(randomBallData);
		}

		private async UniTask<GameObject> GetBallGeneral(IReadOnlyBallData randomBallData)
		{
			if (!TryGetFromPool(out GameObject ball))
			{
				ball = await CreateNewBall();
			}

			InitializeBall(ball, randomBallData);

			return ball;
		}

		private async void InitializeBall(GameObject ball, IReadOnlyBallData randomBallData)
		{
			try
			{
				ball.GetComponent<SpriteRenderer>().sprite = await _assetProvider.Load<Sprite>(randomBallData.Sprite);
			}
			catch (Exception e)
			{
				Debug.LogException(e);
			}
		}

		private async UniTask<GameObject> CreateNewBall()
		{
			GameObject ball = await _assetProvider.Instantiate("Ball");
			ball.AddComponent<ObjectDisableListener>().Disabled += ReturnToPool;
			return ball;
		}

		private IReadOnlyBallData GetAssociatedData(EBallId ballId) => 
			_ballsStaticData.Balls.FirstOrDefault(staticData => staticData.BallId == ballId);

		private bool TryGetFromPool(out GameObject gameObject)
		{
			bool result = _freeObjects.Count > 0;
			gameObject = result ? _freeObjects.Pop().gameObject : null;
			return result;
		}

		private void ReturnToPool(ObjectDisableListener obj) => 
			_freeObjects.Push(obj);
		
		private void WarmUp()
		{
			foreach (IReadOnlyBallData i in _ballsStaticData.Balls)
			{
				_assetProvider.Load<Sprite>(i.Sprite).Forget();
			}
		}
	}
}