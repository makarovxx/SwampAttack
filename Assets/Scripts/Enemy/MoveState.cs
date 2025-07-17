using Enemy.StateMachine;
using UnityEngine;

namespace Enemy
{
    public class MoveState : State
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.position =
                Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        }
    }
}