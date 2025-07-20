using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
    public class PlayerController : LiveUnit
    {
        private const string ShootTriggerName = "Shoot";
        [SerializeField] private List<Weapons.Weapon> _weapons;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private KeyCode _shootKey;

        private Weapons.Weapon _currentWeapon;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private Vector2 Direction => _spriteRenderer.flipX ? Vector2.left : Vector2.right;
        public int Money { get; private set; }

        private void Start()
        {
            _currentWeapon = _weapons[0];
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyUp(_shootKey))
            {
                TryShoot();
            }
        }

        private void TryShoot()
        {
            _currentWeapon.Shoot(Direction, _shootPoint);
            _animator.SetTrigger(ShootTriggerName);
        }

        public void AddMoney(int amount) => Money += amount;
    }
}