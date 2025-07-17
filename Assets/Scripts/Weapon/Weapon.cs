using UnityEngine;

namespace Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private string _name;
        [SerializeField] private int _price;
        [SerializeField] private Sprite _icon;
        [SerializeField] private bool _isPurchased;
        [SerializeField] protected Projectile Projectile;

        public void Shoot(Vector2 direction, Transform shootPoint)
        {
            var projectile = Instantiate(Projectile,shootPoint.position, Quaternion.identity);
            projectile.SetDirection(direction);
        }
        
    }
}
