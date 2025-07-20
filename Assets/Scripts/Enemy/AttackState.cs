using Enemy.StateMachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy
{
    public abstract class AttackState : State
    {
        [FormerlySerializedAs("_damage")] [SerializeField] protected int Damage;
        [FormerlySerializedAs("_delay")] [SerializeField] protected float Delay;
        protected float LastAttackTime;
        protected Animator Animator;

        protected abstract void Attack();
    }
}