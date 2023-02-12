using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KODUA
{
    public class GunAnimator : MonoBehaviour
    {
        Animator _animator;
        Gun _myGun;
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        private void OnEnable()
        {
            _myGun.SetAsAvailable();
        }
        public void SetMyGun(Gun myGun)
        {
            _myGun= myGun;
        }
        public void Shoot()
        {
            _animator.SetTrigger(AnimatorParameters.Attack);
        }
        public void Reload()
        {
            _animator.SetTrigger(AnimatorParameters.Reload);
        }

        public void OnReloadFinished()
        {
            _myGun.SetAsAvailable();
        }
    }

}