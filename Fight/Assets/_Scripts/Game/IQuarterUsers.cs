using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KODUA
{
    public interface IQuarterUsers 
    {
        void Awake();
        void OnEnable();
        void OnDisable();
        void PunchLeft();
        void PunchRight();
        void KickLeft();
        void KickRight();
    }

}