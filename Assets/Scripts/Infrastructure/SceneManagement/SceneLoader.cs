using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.SceneManagement
{
	public class SceneLoader : ISceneLoader
	{
		public async UniTask LoadSceneAsync(string sceneName, Action onLoaded = null)
		{
			if (SceneManager.GetActiveScene().name == sceneName)
			{
				onLoaded?.Invoke();
				return;
			}
			AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
			await asyncOperation.ToUniTask();
			onLoaded?.Invoke();
			Debug.Log("Loaded scene: " + sceneName);
		}
	}
}