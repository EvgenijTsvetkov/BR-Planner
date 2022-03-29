using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class MenuHanlder : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _exitButton;

        private void Awake() =>
            AddListeners();

        private void Start()
        {
        }

        private void OnDestroy() =>
            RemoveListeners();

        private void AddListeners()
        {
            _exitButton.onClick.AddListener(OnClickExitButton);
        }

        private void RemoveListeners()
        {
            _exitButton.onClick.RemoveListener(OnClickExitButton);
        }

        private void OnClickExitButton() =>
            Application.Quit();
    }
}
