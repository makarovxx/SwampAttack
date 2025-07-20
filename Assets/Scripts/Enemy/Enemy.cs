using System;
using UnityEngine;

namespace Enemy
{
    public class Enemy : LiveUnit
    {
        [SerializeField] private int _reward;
        
        public int Reward => _reward;
        private Player.Player _target;

        public Player.Player Target => _target;
        
        public void Init(Player.Player target) => _target = target;
    }
}