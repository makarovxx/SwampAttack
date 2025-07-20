using Player;
using UnityEngine;

namespace Enemy.StateMachine
{
    public abstract class Transition : MonoBehaviour
    {
        [SerializeField] private State _targetState;
        protected PlayerController Target { get; private set; }

        public State TargetState => _targetState;
        public bool NeedTransit { get; protected set; }

        public void Init(PlayerController target) => Target = target;

        private void OnEnable() => NeedTransit = false;
    }
}