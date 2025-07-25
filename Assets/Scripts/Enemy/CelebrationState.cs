using Enemy.StateMachine;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Animator))]
    public class CelebrationState : State
    {
        private const string AnimCelebrationName = "Celebration";
        private Animator _animator;

        private void Awake() => _animator = GetComponent<Animator>();

        private void OnEnable() => _animator.Play(AnimCelebrationName);

        private void OnDisable() => _animator.StopPlayback();
    }
}