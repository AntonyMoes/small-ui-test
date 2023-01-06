using System;
using GeneralUtils;
using UnityEngine;

namespace _Game.Scripts.UI {
    public class GameUIController : SingletonBehaviour<GameUIController> {
        [SerializeField] private GameUI _gameUI;
        [SerializeField] private MainMenuWindow _mainMenuWindow;
        [SerializeField] private SettingsWindow _settingsWindow;
        [SerializeField] private Transform _hider;
        [SerializeField] private Transform _windows;

        public MainMenuWindow ShowMainMenuWindow(Action onDone) {
            _mainMenuWindow.Show(onDone);
            return _mainMenuWindow;
        }

        public SettingsWindow ShowSettingsWindow(Action onDone) {
            _settingsWindow.Show(onDone);
            return _settingsWindow;
        }

        public GameUI ShowGameUI(Action onDone) {
            _gameUI.Show(onDone);
            return _gameUI;
        }

        public void ShowWindow(Window window) {
            _hider.gameObject.SetActive(true);
            _hider.SetAsLastSibling();
            window.transform.SetAsLastSibling();
        }

        public void HideWindow(Window _) {
            Window lastActiveWindow = null;
            foreach (Transform child in _windows) {
                if (child.gameObject.activeSelf && child.TryGetComponent<Window>(out var activeWindow))
                    lastActiveWindow = activeWindow;
            }

            if (lastActiveWindow != null) {
                _hider.SetSiblingIndex(lastActiveWindow.transform.GetSiblingIndex());
            } else {
                _hider.gameObject.SetActive(false);
            }
        }
    }
}