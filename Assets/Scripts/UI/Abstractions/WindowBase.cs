using UnityEngine;
using UnityEngine.UI;

namespace UI.Abstractions
{
	public class WindowBase : MonoBehaviour
	{
		[SerializeField]
		protected Button closeButton;
		
		private void Awake()
		{
			OnAwake();
		}

		protected virtual void OnAwake()
		{
			closeButton.onClick.AddListener(Hide);
		}
		
		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}
	}
}