using System;
using UI.Abstractions;
using UnityEngine;
using UnityEngine.UI;

namespace UI.StartScreen
{
    public class StartScreen : WindowBase
    {
        [SerializeField] private Button startButton;
        public event Action StartInvoked;

        public bool Interactable
        {
            get => startButton.interactable;
            set => startButton.interactable = value;
        }

        protected override void OnAwake()
        {
            startButton.onClick.AddListener(OnStartPressed);
        }

        private void OnStartPressed()
        {
            StartInvoked?.Invoke();
        }
    }
}
