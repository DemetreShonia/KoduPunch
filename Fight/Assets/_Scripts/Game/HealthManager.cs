using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KODUA
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] float _maxHealth;
        float _currentHealth;

        [SerializeField] float _regenerationSpeed;
        [SerializeField] float _damage;


        void Start()
        {
            _currentHealth = _maxHealth;
        }

        void Update()
        {
            // regeneration
            _currentHealth += Time.deltaTime * _regenerationSpeed;
            ClampHealth();
        }

        void ClampHealth()
        {
            // Clamp in bounds
            _currentHealth = Mathf.Clamp01(_currentHealth);
        }

        // use this to play LAUGH animations when you do not kick his ass!!
        public bool HasFullHealth() => _currentHealth >= 0.8f;
        public void TakeDamage()
        {
            // call this when you hit
            _currentHealth -= _damage;
            ClampHealth();
        }
    }

}