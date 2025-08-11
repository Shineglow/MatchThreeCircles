using System;
using com.shineglow.di.Runtime;
using Cysharp.Threading.Tasks;
using Infrastructure.AssetManagement;
using Infrastructure.DI;
using Infrastructure.Factories.BallsFactory;
using Infrastructure.Factories.GameFactory;
using Infrastructure.Factories.UiFactory;
using Infrastructure.SceneManagement;
using Infrastructure.Windows;
using StaticData.BallsStaticData;
using UI.Loading.LoadingScreen;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.GameplayFSM.States
{
	public class BootstrapState : IState
	{
		private readonly DIResolverWrapper _container;
		private readonly IGameplayStateMachine _stateMachine;
		private readonly IGame _game;

		[Inject]
		public BootstrapState(DIResolverWrapper container, IGameplayStateMachine stateMachine)
		{
			_container = container;
			_stateMachine = stateMachine;
		}
		
		public void Exit(){}

		public async void Enter()
		{
			await ContainerBindings();
		}

		private async UniTask ContainerBindings()
		{
			try
			{
				IAssetProvider assetProvider = _container.Resolve<IAssetProvider>();

				assetProvider.Load<GameObject>(AssetAddress.UiRoot).Forget();
				var loadingScreen = (await assetProvider.Instantiate(AssetAddress.LoadingCurtain)).GetComponent<LoadingScreen>();
				Object.DontDestroyOnLoad(loadingScreen);
				loadingScreen.Show();
				loadingScreen.UpdateProgress(0f);

				_container.Bind<IUiFactory>().To<UiFactory>().IsCachingInstance();
				_container.Bind<IWindowService>().To<WindowService>().IsCachingInstance();
				_container.Bind<ISceneLoader>().To<SceneLoader>().IsCachingInstance();
				_container.Bind<IBallFactory>().To<BallFactory>().IsCachingInstance();
				_container.Bind<IGameFactory>().To<GameFactory>().IsCachingInstance();
				_container.Bind<IBallsStaticData>().AsInstance(await assetProvider.Load<IBallsStaticData>(StaticDataAddress.BallStaticData));

				await _container.Resolve<ISceneLoader>().LoadSceneAsync("MainMenu", onLoaded: EnterGameplayState);
				loadingScreen.Hide();
			}
			catch (Exception e)
			{
				Debug.LogException(e);
			}
		}

		private void EnterGameplayState()
		{
			_stateMachine.Enter<StartGameState>();
		}
	}
}