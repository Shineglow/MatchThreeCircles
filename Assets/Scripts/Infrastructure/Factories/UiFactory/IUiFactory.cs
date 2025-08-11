using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Factories.UiFactory
{
	public interface IUiFactory
	{
		UniTask<GameObject> CreateUIRoot();
		UniTask<GameObject> CreateStartScreen();
		UniTask<GameObject> CreateScreenTouchDetector();
		UniTask<GameObject> CreateLoadingCurtain();
	}
}