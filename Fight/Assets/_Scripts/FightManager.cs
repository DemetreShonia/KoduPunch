using UnityEngine;

namespace KODUA
{
    public class FightManager : MonoBehaviour
    {
        Vector3 _mousePos;
        [SerializeField] Animator _animator;
        [SerializeField] BootsAndBita _bootsAndBita;

        private void Update()
        {
            CheckInput();
        }
        void CheckInput()
        {
            _mousePos = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                CheckQuarters();
            }
        }
        void CheckQuarters()
        {
            if (_mousePos.x < Screen.width / 2 && _mousePos.y < Screen.height / 2)
            {
                _animator.SetTrigger(AnimatorParameters.LeftKick);
                _bootsAndBita.KickLeft();
            }
            else if (_mousePos.x >= Screen.width / 2 && _mousePos.y < Screen.height / 2)
            {
                _animator.SetTrigger(AnimatorParameters.RightKick);
                _bootsAndBita.KickRight();
            }
            else if (_mousePos.x < Screen.width / 2 && _mousePos.y >= Screen.height / 2)
            {
                _animator.SetTrigger(AnimatorParameters.LeftPunch);
                _bootsAndBita.PunchLeft();
            }
            else if (_mousePos.x >= Screen.width / 2 && _mousePos.y >= Screen.height / 2)
            {
                _animator.SetTrigger(AnimatorParameters.RightPunch);
                _bootsAndBita.PunchRight();
            }
        }
    }

}