using UnityEngine;

namespace KODUA
{
    public enum WeaponType
    {
        Melee, Gun
    }
    public class FightManager : MonoBehaviour, IQuarterUsers
    {
        [SerializeField] Animator _animator;
        [SerializeField] BootsAndBita _bootsAndBita;
        [SerializeField] Gun _gun;

        WeaponType _currentWeaponType;
        InputManager _inputManager;

        Weapon _currentWeapon;
        public void Awake()
        {
            _inputManager = InputManager.Instance;
        }
        private void Start()
        {
            ChangeCurrentWeaponType(WeaponType.Melee);
        
        }
        public void SetAnimator(Animator animator)
        {
            _animator = animator;
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
        }
        public void ChangeCurrentWeaponType(WeaponType newType)
        {
            _currentWeaponType = newType;

            switch (newType)
            {
                case WeaponType.Melee:
                    _bootsAndBita.Activate();
                    _gun.Deactivate();
                    _currentWeapon = _bootsAndBita;
                    break;
                case WeaponType.Gun:
                    _bootsAndBita.Deactivate();
                    _gun.Activate();
                    _currentWeapon = _gun;
                    break;
            }
        }
        public void PunchLeft()
        {
            if (!_currentWeapon.IsAvailable) return;
            _animator.SetTrigger(AnimatorParameters.LeftPunch);
        }

        public void PunchRight()
        {
            if (!_currentWeapon.IsAvailable) return;
            _animator.SetTrigger(AnimatorParameters.RightPunch);
        }

        public void KickLeft()
        {
            if (!_currentWeapon.IsAvailable) return;
            _animator.SetTrigger(AnimatorParameters.LeftKick);
        }

        public void KickRight()
        {
            if (!_currentWeapon.IsAvailable) return;
            _animator.SetTrigger(AnimatorParameters.RightKick);
        }
    }

}