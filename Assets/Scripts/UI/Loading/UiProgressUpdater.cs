using UI.Abstractions;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Loading
{
	public class UiProgressUpdater :  ProgressUpdater
	{
		[SerializeField]
		private Image _progressBar;
		
		public override void UpdateProgress(float normolizedProgress)
		{
			_progressBar.fillAmount = normolizedProgress;
		}
	}
}