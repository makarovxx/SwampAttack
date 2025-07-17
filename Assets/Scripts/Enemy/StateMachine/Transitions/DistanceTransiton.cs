using Enemy.StateMachine;
using UnityEngine;

public class DistanceTransiton : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangedSpread;

    private void Start() => _transitionRange += Random.Range(-_rangedSpread, _rangedSpread);

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _transitionRange)
            NeedTransit = true;
    }
}