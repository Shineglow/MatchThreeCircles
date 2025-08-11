using System;
using Cysharp.Threading.Tasks;

namespace Infrastructure.SceneManagement
{
	public interface ISceneLoader
	{
		UniTask LoadSceneAsync(string sceneName, Action onLoaded = null);
	}
}