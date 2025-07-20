using Player;
using UnityEngine;

namespace Enemy
{
    public class Enemy : LiveUnit
    {
        [SerializeField] private int _reward;
        
        public int Reward => _reward;
        private PlayerController _target;

        public PlayerController Target => _target;
        
        public void Init(PlayerController target) => _target = target;
    }
}