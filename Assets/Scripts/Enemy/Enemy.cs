using System;
using UnityEngine;

namespace Enemy
{
    public class Enemy : LiveUnit
    {
        [SerializeField] private Player.Player _target;

        public Player.Player Target => _target;
        public event Action OnDie;
    }
}