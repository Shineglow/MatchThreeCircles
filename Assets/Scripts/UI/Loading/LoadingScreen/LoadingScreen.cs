using System.Collections;
using UI.Abstractions;
using UnityEngine;

namespace UI.Loading.LoadingScreen
{
    public class LoadingScreen : ProgressUpdater, ILoadingScreen
    {
        [SerializeField]
        CanvasGroup canvasGroup;
        [SerializeField]
        private ProgressUpdater progressUpdater;
    
        public void Show()
        {
            canvasGroup.alpha = 1f;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn()
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= 0.03f;
                yield return null;
            }
            gameObject.SetActive(false);
        }

        public override void UpdateProgress(float normolizedProgress)
        {
            progressUpdater.UpdateProgress(normolizedProgress);
        }
    }
}
