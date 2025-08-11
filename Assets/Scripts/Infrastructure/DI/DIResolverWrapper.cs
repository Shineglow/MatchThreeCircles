using com.shineglow.di.Runtime;
using Gameplay.Spawners;
using Infrastructure.Factories.BallsFactory;

namespace Infrastructure.DI
{
	public class DIResolverWrapper : DiContainer, IResolver
	{
		public void ResolveBallSpawner(BallSpawner instance)
		{
			instance.Construct(Resolve<IBallFactory>());
		}
	}
}