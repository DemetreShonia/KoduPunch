using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KODUA
{
    public class BootsAndBita : Weapon, IQuarterUsers
    {
        [SerializeField] GameObject _leftBoot, _rightBoot;
        [SerializeField] GameObject _leftBita, _rightBita;

        InputManager _inputManager;
        Coroutine _innerCo;
        public void Awake()
        {
            _inputManager = InputManager.Instance;
            IsAvailable = true;
        }
        public void OnEnable()
        {
            _inputManager.onClickedUpRight += PunchRight;
            _inputManager.onClickedUpLeft += PunchLeft;
            _inputManager.onClickedDownRight += KickRight;
            _inputManager.onClickedDownLeft += KickLeft;
        }
        public void OnDisable()
        {
            _inputManager.onClickedUpRight -= PunchRight;
            _inputManager.onClickedUpLeft -= PunchLeft;
            _inputManager.onClickedDownRight -= KickRight;
            _inputManager.onClickedDownLeft -= KickLeft;
            DisableAllGameObjects();
        }
        void DisableAllGameObjects()
        {
            _leftBoot.SetActive(false);
            _rightBita.SetActive(false);
            _rightBoot.SetActive(false);
            _leftBita.SetActive(false);
            StopCoroutine(_innerCo);
        }

        public void PunchLeft()
        {
            EnableGameObjectFor(_leftBita, 0.4f);
        }
        public void PunchRight()
        {
            EnableGameObjectFor(_rightBita, 0.4f);
        }
        public void KickLeft()
        {
            EnableGameObjectFor(_leftBoot, 0.4f);
        }
        public void KickRight()
        {
            EnableGameObjectFor(_rightBoot, 0.4f);
        }
        void EnableGameObjectFor(GameObject go, float delay)
        {
            if (!IsActive) return;
            _innerCo = StartCoroutine(InnerCo());

            IEnumerator InnerCo()
            {
                go.SetActive(true);
                for (float i = 0.0f; i < delay; i += Time.deltaTime)
                {
                    yield return null;
                }
                go.SetActive(false);
            }
        }

        
    } 
}
