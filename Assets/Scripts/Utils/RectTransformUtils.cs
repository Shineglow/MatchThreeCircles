using UnityEngine;

namespace Utils
{
	public static class RectTransformUtils
	{
		public static void FitParent(ref RectTransform rectTransform)
		{
			rectTransform.anchorMin = Vector2.zero;
			rectTransform.anchorMax = Vector2.one;
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;
		}
	}
}