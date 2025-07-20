using System;
using UnityEngine;

namespace Enemy
{
    public class LiveUnit : MonoBehaviour
    {
        [SerializeField] protected int _health;
        
        public event Action<LiveUnit> OnDie;

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                OnDie?.Invoke(this);
                Destroy(gameObject);
            }
        }
    }
}