using UnityEngine;

namespace Enemy
{
    public class LiveUnit : MonoBehaviour
    {
        [SerializeField] protected int _health;
        [SerializeField] private int _reward;
        
        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
                Destroy(gameObject);
        }
    }
}