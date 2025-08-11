using System;
using Infrastructure.SceneManagement;
using Infrastructure.Windows;
using UI.Loading.LoadingScreen;
using UI.StartScreen;
using UnityEngine;

namespace Infrastructure.GameplayFSM.States
{
	public class StartGameState : IState
	{
		private readonly IWindowService _windowService;
		private readonly IGameplayStateMachine _gameplayStateMachine;
		private StartScreen _startScreen;

		public StartGameState(IWindowService windowService, IGameplayStateMachine gameplayStateMachine)
		{
			_windowService = windowService;
			_gameplayStateMachine = gameplayStateMachine;
		}
		
		public void Exit()
		{
			_startScreen.Hide();
			_startScreen = null;
		}

		public async void Enter()
		{
			GameObject startScreenGo = await _windowService.GetWindow(EWindowId.StartScreen);
			_startScreen = startScreenGo.GetComponent<StartScreen>();
			_startScreen.Show();
			_startScreen.StartInvoked += LoadGameplay;
		}

		private async void LoadGameplay()
		{
			_startScreen.Interactable = false;
			LoadingScreen curtain = (await _windowService.GetWindow(EWindowId.LoadingCurtain)).GetComponent<LoadingScreen>();
			curtain.Show();
			_gameplayStateMachine.Enter<GameplayMainState>();
		}
	}
}