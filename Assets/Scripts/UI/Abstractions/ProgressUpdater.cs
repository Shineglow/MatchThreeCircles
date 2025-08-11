using UnityEngine;

namespace UI.Abstractions
{
	public abstract class ProgressUpdater : MonoBehaviour
	{
		public abstract void UpdateProgress(float normolizedProgress);
	}
}