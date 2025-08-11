using Cysharp.Threading.Tasks;
using Infrastructure.AssetManagement;
using UnityEngine;

namespace Infrastructure.Factories.UiFactory
{
	public class UiFactory : IUiFactory
	{
		private readonly IAssetProvider _assetProvider;

		public UiFactory(IAssetProvider assetProvider)
		{
			_assetProvider = assetProvider;
		}
		
		public async UniTask<GameObject> CreateUIRoot()
		{
			return await _assetProvider.Instantiate(AssetAddress.UiRoot);
		}

		public async UniTask<GameObject> CreateStartScreen()
		{
			return await _assetProvider.Instantiate(AssetAddress.StartScreen);
		}

		public async UniTask<GameObject> CreateScreenTouchDetector()
		{
			return await _assetProvider.Instantiate(AssetAddress.ScreenTouchDetector);
		}

		public async UniTask<GameObject> CreateLoadingCurtain()
		{
			return await _assetProvider.Instantiate(AssetAddress.LoadingCurtain);
		}
	}
}