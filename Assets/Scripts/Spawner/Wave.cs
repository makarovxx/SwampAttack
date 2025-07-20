using System;
using UnityEngine;

[Serializable]
public class Wave
{
    [SerializeField] private Enemy.Enemy _template;
    [SerializeField] private int _count;
    [SerializeField] private float _delay;

    public Enemy.Enemy Template => _template;
    public int Count => _count;
    public float Delay => _delay;
}