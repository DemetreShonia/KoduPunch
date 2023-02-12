using UnityEngine;

namespace KODUA
{
    public class Gun : Weapon
    {
        [SerializeField] GameObject _gunGameObject;
        GunAnimator _gunAnimator;
        InputManager _inputManager;

        const int MAX_AMMO_COUNT = 6;

        int _currentAmmoCount = 0;
        private void Awake()
        {
            _inputManager = InputManager.Instance;
            _currentAmmoCount = MAX_AMMO_COUNT;
            IsAvailable = true;
        }
        private void OnEnable()
        {
            _inputManager.onClickedMouse += Shoot;
        }
        private void OnDisable()
        {
            _inputManager.onClickedMouse -= Shoot;
        }
        private void Start()
        {
            _gunAnimator = _gunGameObject.GetComponent<GunAnimator>();
            _gunAnimator.SetMyGun(this);
        }
        public override void Activate()
        {
            base.Activate();
            _gunGameObject.SetActive(true);
        }
        public override void Deactivate()
        {
            base.Deactivate();
            _gunGameObject.SetActive(false);
        }
        void Shoot()
        {
            if (!IsActive || !IsAvailable) return;


            _gunAnimator.Shoot();
            _currentAmmoCount--;

            if(_currentAmmoCount <= 0)
            {
                IsAvailable = false;
                Reload();
            }
        }
        void Reload()
        {
            // reload
            _currentAmmoCount = MAX_AMMO_COUNT;
            _gunAnimator.Reload();
        }
        // When Reload Finishes
        public void SetAsAvailable()
        {
            IsAvailable = true;
        }
    }

}