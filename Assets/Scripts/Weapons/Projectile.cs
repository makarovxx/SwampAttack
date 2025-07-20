using Enemy;
using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime = 1.5f;
        [SerializeField] private Vector2 _direction = Vector2.left;
        private SpriteRenderer _spriteRenderer;
        private float _elapsedTime;

        private void Awake() => _spriteRenderer = GetComponent<SpriteRenderer>();

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _lifeTime)
                Destroy(gameObject);

            transform.Translate(_direction * (_speed * Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out LiveUnit target))
            {
                target.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
            _spriteRenderer.flipX = direction.x < 0;
        }
    }
}