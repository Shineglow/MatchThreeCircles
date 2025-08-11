using Gameplay.Spawners;
using Infrastructure.Factories.GameFactory;
using Infrastructure.SceneManagement;
using Infrastructure.Windows;
using UI.Gameplay;
using UI.Loading.LoadingScreen;
using UnityEngine;

namespace Infrastructure.GameplayFSM.States
{
	public class GameplayMainState : IState
	{
		private readonly ISceneLoader _sceneLoader;
		private readonly IGameFactory _gameFactory;
		private readonly IWindowService _windowService;
		
		private GameObject _pendulum;
		private ScreenTouchDetector _screenTouchDetector;
		private BallSpawner _ballSpawner;

		public GameplayMainState(ISceneLoader sceneLoader, IGameFactory gameFactory, IWindowService windowService)
		{
			_sceneLoader = sceneLoader;
			_gameFactory = gameFactory;
			_windowService = windowService;
		}
		
		public void Exit(){}

		public async void Enter()
		{
			await _sceneLoader.LoadSceneAsync("GameplayMain");
			_pendulum = await _gameFactory.CreatePendulum();
			_ballSpawner = _pendulum.GetComponentInChildren<BallSpawner>();
			
			_screenTouchDetector = (await _windowService.GetWindow(EWindowId.ScreenTouchDetector)).GetComponent<ScreenTouchDetector>();
			_screenTouchDetector.TouchDetected += _ballSpawner.TryDropBall;
			// show gameplay hud
			(await _windowService.GetWindow(EWindowId.LoadingCurtain)).GetComponent<LoadingScreen>().Hide();
		}
	}
}