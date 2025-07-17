using Enemy.StateMachine;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
    public class AttackState : State
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _delay;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Weapon.Weapon _weapon;
        private float _lastAttackTime;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private Vector2 Direction => _spriteRenderer.flipX ? Vector2.left : Vector2.right;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable() => _animator.StopPlayback();
        private void Update()
        {
            if (_lastAttackTime <= 0)
            {
                Attack();
                _lastAttackTime = _delay;
            }

            _lastAttackTime -= Time.deltaTime;
        }

        private void Attack()
        {
            _animator.Play("Attack");
            _weapon.Shoot(Direction,_shootPoint);
        }
    }
}