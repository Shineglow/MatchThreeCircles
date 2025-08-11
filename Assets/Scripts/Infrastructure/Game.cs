using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.AssetManagement;
using Infrastructure.DI;
using Infrastructure.Factories.GameFactory;
using Infrastructure.GameplayFSM;
using Infrastructure.GameplayFSM.States;
using StaticData.Levels;
using UnityEngine.AddressableAssets;

namespace Infrastructure
{
	public class Game : IGame
	{
		public IReadOnlyLevelInfo CurrentLevelInfo { get; private set; }
		private GameplayStateMachine _stateMachine;
		private readonly DIResolverWrapper _container = new DIResolverWrapper();

		public Game(ICoroutineRunner coroutineRunner)
		{
			_container.Bind<IGame>().AsInstance(this);
			_container.Bind<ICoroutineRunner>().AsInstance(coroutineRunner);
			var assetProvider = RegisterAssetProvider();
			LoadStaticDataAsync(assetProvider);
			
			_stateMachine = new GameplayStateMachine(_container);
			_stateMachine.Enter<BootstrapState>();
		}

		private IAssetProvider RegisterAssetProvider()
		{
			IAssetProvider assetProvider = new AssetProvider();
			assetProvider.Initialize();
			_container.Bind<IAssetProvider>().AsInstance(assetProvider);
			return assetProvider;
		}

		private async void LoadStaticDataAsync(IAssetProvider assetProvider)
		{
			CurrentLevelInfo = await assetProvider.Load<IReadOnlyLevelInfo>(StaticDataAddress.LevelsStaticData);
		}
	}
}