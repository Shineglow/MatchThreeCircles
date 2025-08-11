using Cysharp.Threading.Tasks;
using Gameplay.Spawners;
using Infrastructure.AssetManagement;
using Infrastructure.DI;
using StaticData.Levels;
using UnityEngine;

namespace Infrastructure.Factories.GameFactory
{
	public class GameFactory : IGameFactory
	{
		private readonly IAssetProvider _assetProvider;
		private readonly IGame _game;
		private readonly IResolver _resolver;

		public GameFactory(IAssetProvider assetProvider, IGame game, IResolver resolver)
		{
			_assetProvider = assetProvider;
			_game = game;
			_resolver = resolver;
		}
		
		public async UniTask<GameObject> CreatePendulum()
		{
			var gameObject = await _assetProvider.Instantiate(AssetAddress.MathematicalPendulum, _game.CurrentLevelInfo.PendulumPosition);

			_resolver.ResolveBallSpawner(gameObject.GetComponentInChildren<BallSpawner>());
			
			return gameObject;
		}
	}

	public interface IGame
	{
		IReadOnlyLevelInfo CurrentLevelInfo { get; }
	}
}