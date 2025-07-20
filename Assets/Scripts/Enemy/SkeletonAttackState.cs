namespace Enemy
{
    public class SkeletonAttackState : AttackState
    {
        protected override void Attack()
        {
            Animator.Play("Attack");
            Target.TakeDamage(Damage);
        }
    }
}