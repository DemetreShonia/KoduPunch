using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KODUA
{
    public class BootsAndBita : MonoBehaviour
    {
        [SerializeField] GameObject _leftBoot, _rightBoot;
        [SerializeField] GameObject _leftBita, _rightBita;

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
            StartCoroutine(InnerCo());

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
