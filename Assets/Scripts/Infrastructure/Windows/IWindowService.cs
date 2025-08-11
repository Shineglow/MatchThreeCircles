using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Windows
{
	public interface IWindowService
	{
		UniTask<GameObject> GetWindow(EWindowId windowId);
	}
}