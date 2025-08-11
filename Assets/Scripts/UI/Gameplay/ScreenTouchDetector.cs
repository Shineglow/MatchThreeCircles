using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Gameplay
{
	public class ScreenTouchDetector : MonoBehaviour
	{
		[SerializeField] Button _button;
		public event Action TouchDetected;
		
		private void Awake()
		{
			_button.onClick.AddListener(OnTouch);
		}

		private void OnTouch()
		{
			TouchDetected?.Invoke();
		}
	}
}