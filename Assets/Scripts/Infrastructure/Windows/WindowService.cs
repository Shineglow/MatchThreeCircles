using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Factories;
using Infrastructure.Factories.UiFactory;
using UI.Root;
using UnityEngine;
using Utils;
using Object = UnityEngine.Object;

namespace Infrastructure.Windows
{
	public class WindowService : IWindowService
	{
		private readonly IUiFactory _uiFactory;
		private IUiRoot _uiRoot;
		private GameObject _loadingCurtain;

		public WindowService(IUiFactory uiFactory)
		{
			_uiFactory = uiFactory;
			InitUiRoot();
		}

		public async UniTask<GameObject> GetWindow(EWindowId windowId)
		{
			GameObject window = null;
			switch (windowId)
			{
				case EWindowId.StartScreen:
					window = await _uiFactory.CreateStartScreen();
					var startScreenTransform = window.GetComponent<RectTransform>();
					_uiRoot.PlaceOnMediumLevel(startScreenTransform);
					RectTransformUtils.FitParent(ref startScreenTransform); 
					break;
				case EWindowId.LoadingCurtain:
					window = await GetCachedLoadingCurtain();
					break;
				case EWindowId.ScreenTouchDetector:
					window = await _uiFactory.CreateScreenTouchDetector();
					var screenTouchTransform = window.GetComponent<RectTransform>();
					_uiRoot.PlaceOnLowLevel(screenTouchTransform);
					RectTransformUtils.FitParent(ref screenTouchTransform);
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(windowId), windowId, null);
			}
			return await UniTask.FromResult(window);
		}

		private async UniTask<GameObject> GetCachedLoadingCurtain()
		{
			if (!_loadingCurtain)
			{
				_loadingCurtain = await _uiFactory.CreateLoadingCurtain();
				var loadingCurtainTransform = _loadingCurtain.GetComponent<RectTransform>();
				_uiRoot.PlaceOnMediumLevel(loadingCurtainTransform);
				RectTransformUtils.FitParent(ref loadingCurtainTransform);
			}
			return _loadingCurtain;
		}

		private async void InitUiRoot()
		{
			try
			{
				var uiRootGo = await _uiFactory.CreateUIRoot();
				_uiRoot = uiRootGo.GetComponent<IUiRoot>();
				Object.DontDestroyOnLoad(uiRootGo);
			}
			catch (Exception e)
			{
				Debug.LogException(e);
			}
		}
	}
}