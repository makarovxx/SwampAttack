using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
    public class ArcherAttackState : AttackState
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Weapon.Weapon _weapon;

        private SpriteRenderer _spriteRenderer;
        private Vector2 Direction => _spriteRenderer.flipX ? Vector2.left : Vector2.right;

        private void Awake()
        {
            Animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable() => Animator.StopPlayback();
        private void Update()
        {
            if (LastAttackTime <= 0)
            {
                Attack();
                LastAttackTime = Delay;
            }

            LastAttackTime -= Time.deltaTime;
        }

        protected override void Attack()
        {
            Animator.Play("Attack");
            _weapon.Shoot(Direction,_shootPoint);
        }
    }
}