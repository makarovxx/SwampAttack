using Player;
using UnityEngine;

namespace Enemy.StateMachine
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private State _startState;
        private State _currentState;
        private PlayerController _target;

        public State CurrentState => _currentState;

        private void Start()
        {
            _target = GetComponent<Enemy>().Target;
            Reset(_startState);
        }

        private void Update()
        {
            if (!_currentState)
            {
                return;
            }

            var next = _currentState.GetNextState();
            
            if(next) Transit(next);
        }

        private void Transit(State nextState)
        {
            if(_currentState) _currentState.Exit();
            
            _currentState = nextState;

            if (_currentState)
            {
                _currentState.Enter(_target);
            }
        }
        
        private void Reset(State startState)
        {
            _currentState = startState;

            if (_currentState != null)
            {
                _currentState.Enter(_target);
            }
        }
    }
}