using System;
using Infrastructure.DI;
using Infrastructure.SceneManagement;
using UnityEngine;

namespace Infrastructure
{
	public class Bootstrapper : MonoBehaviour
	{
		private readonly DIResolverWrapper _container = new DIResolverWrapper();

		private async void Awake()
		{
			try
			{
				_container.Bind<IResolver>().AsInstance(_container);
				_container.Bind<ISceneLoader>().To<SceneLoader>().IsCachingInstance();

				// show loadingScreen
				await _container.Resolve<ISceneLoader>().LoadSceneAsync("Main");
				// hide loadingScreen
				// move control to gameplay
			}
			catch (Exception e)
			{
				Debug.LogException(e);
			}
		}
	}
}
