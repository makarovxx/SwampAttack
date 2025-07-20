using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ArcherAttackState : AttackState
    {
        private const string AttackNameAnim = "Attack";
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Weapons.Weapon _weapon;

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
            Animator.Play(AttackNameAnim);
            _weapon.Shoot(Direction,_shootPoint);
        }
    }
}