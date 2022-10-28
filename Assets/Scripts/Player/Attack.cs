namespace Script.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using Script.ObserverPattern;

    public class Attack : MonoBehaviour
    {
        private Utility _utility;
        private Rigidbody2D _rb;

        [SerializeField]
        private Subject _onPlayerAttack;
        [SerializeField]
        private GameObject _weapon;
        private Animator _animator;

        // Start is called before the first frame update
        void Start()
        {
            _utility = GetComponent<Utility>();
            _rb = GetComponent<Rigidbody2D>();
            _animator = _weapon.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AttackInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _onPlayerAttack.Trigger();
                _animator.SetTrigger("Swing");
            }
        }
        public void AttackUpInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _onPlayerAttack.Trigger();
                _animator.SetTrigger("SwingUp");
            }
        }
        public void AttackDownInput(InputAction.CallbackContext context)
        {
            if (context.started && !_utility.IsGrounded())
            {
                _onPlayerAttack.Trigger();
                _animator.SetTrigger("SwingDown");
            }
        }
    }

}