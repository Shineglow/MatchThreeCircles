using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Factories.BallsFactory
{
	public interface IBallFactory
	{
		UniTask<GameObject> GetRandomBall();
		UniTask<GameObject> GetBall(EBallId ballId);
	}
}