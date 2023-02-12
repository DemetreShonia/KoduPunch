using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KODUA
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] FightManager _fightManager;

        public void SelectMelee()
        {
            _fightManager.ChangeCurrentWeaponType(WeaponType.Melee);
        }
        public void SelectGun()
        {
            _fightManager.ChangeCurrentWeaponType(WeaponType.Gun);
        }
    }

}