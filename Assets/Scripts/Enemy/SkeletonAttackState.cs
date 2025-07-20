namespace Enemy
{
    public class SkeletonAttackState : AttackState
    {
        private const string AnimAttackName = "Attack"; 
        protected override void Attack()
        {
            Animator.Play(AnimAttackName);
            Target.TakeDamage(Damage);
        }
    }
}