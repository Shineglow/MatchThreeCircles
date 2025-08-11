using UnityEngine;

namespace UI.Root
{
	public interface IUiRoot
	{
		void PlaceOnLowLevel(RectTransform uiTransform);
		void PlaceOnMediumLevel(RectTransform uiTransform);
		void PlaceOnOverlayLevel(RectTransform uiTransform);
	}
}