using Gameplay.Spawners;

namespace Infrastructure.DI
{
	public interface IResolver
	{
		T Resolve<T>(string id = null);
		void ResolveBallSpawner(BallSpawner instance);
	}
}