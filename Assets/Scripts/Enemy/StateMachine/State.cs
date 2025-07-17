using System.Collections.Generic;
using UnityEngine;

namespace Enemy.StateMachine
{
    public class State : MonoBehaviour
    {
        [SerializeField] private List<Transition> _transitions;
        public Player.Player Target { get; protected set; }

        public void Enter(Player.Player target)
        {
            if (enabled == false)
            {
                Target = target;
                enabled = true;
                foreach (var t in _transitions)
                {
                    t.enabled = true;
                    t.Init(Target);
                }
            }
        }

        public void Exit()
        {
            if (enabled)
            {
                foreach (var t in _transitions)
                {
                    t.enabled = false;
                }
                enabled = false;
            }
        }
        
        public State GetNextState()
        {
            foreach (var t in _transitions)
            {
                if (t.NeedTransit)
                {
                    return t.TargetState;
                }
            }
            return null;
        }
    }
}