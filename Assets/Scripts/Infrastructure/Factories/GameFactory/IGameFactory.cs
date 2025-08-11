using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Factories.GameFactory
{
	public interface IGameFactory
	{
		UniTask<GameObject> CreatePendulum();
	}
}