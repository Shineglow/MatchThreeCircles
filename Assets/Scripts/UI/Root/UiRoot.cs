using UnityEngine;

namespace UI.Root
{
	public class UiRoot : MonoBehaviour, IUiRoot
	{
		[SerializeField] private RectTransform low;
		[SerializeField] private RectTransform medium;
		[SerializeField] private RectTransform overlay;

		public void PlaceOnLowLevel(RectTransform uiTransform)
		{
			uiTransform.SetParent(low);
		}
		
		public void PlaceOnMediumLevel(RectTransform uiTransform)
		{
			uiTransform.SetParent(medium);
		}
		
		public void PlaceOnOverlayLevel(RectTransform uiTransform)
		{
			uiTransform.SetParent(overlay);
		}
	}
}