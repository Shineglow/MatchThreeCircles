using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.SceneManagement
{
	public class SceneLoader : ISceneLoader
	{
		public async UniTask LoadSceneAsync(string sceneName)
		{
			if (SceneManager.GetActiveScene().name == sceneName)
				return;
			AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
			await asyncOperation.ToUniTask();
			Debug.Log("Loaded scene: " + sceneName);
		}
	}
}