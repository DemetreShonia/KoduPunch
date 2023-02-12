using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KODUA
{
    public class InputManager : MonoBehaviour
    {
        #region Singleton

        public static InputManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        #endregion
        public Vector3 MousePosition => (Vector3)_mousePos;
        Vector2 _mousePos;

        public Action onClickedUpLeft, onClickedUpRight, onClickedDownLeft, onClickedDownRight;
        public Action onClickedMouse;
        void Update()
        {
            CheckInput();
        }
        void CheckInput()
        {
            _mousePos = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                onClickedMouse?.Invoke();
                ClickOnQuarter();
            }
        }
        void ClickOnQuarter()
        {
            if (_mousePos.x < Screen.width / 2 && _mousePos.y < Screen.height / 2)
            {
                print("DownLEFT");
                onClickedDownLeft?.Invoke();
            }
            else if (_mousePos.x >= Screen.width / 2 && _mousePos.y < Screen.height / 2)
            {
                print("DownRight");
                onClickedDownRight?.Invoke();
            }
            else if (_mousePos.x < Screen.width / 2 && _mousePos.y >= Screen.height / 2)
            {
                print("UpLeft");
                onClickedUpLeft?.Invoke();
            }
            else if (_mousePos.x >= Screen.width / 2 && _mousePos.y >= Screen.height / 2)
            {
                print("UpRight");
                onClickedUpRight?.Invoke();
            }
        }
    } 
}
