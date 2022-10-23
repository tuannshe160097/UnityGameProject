using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public float JumpPower;
    public int MaxJumpCounter;

    private int _jumpCounter;

    private Look _lookAction;

    private Utility _utility;
    private Rigidbody2D _rb;

    [SerializeField]
    private Subject _onPlayerJump;

    // Start is called before the first frame update
    void Start()
    {
        _utility = GetComponent<Utility>();
        _rb = GetComponent<Rigidbody2D>();
        _jumpCounter = MaxJumpCounter;

        _lookAction = GetComponent<Look>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_jumpCounter == 0 && _utility.MovementResetable())
        {
            _jumpCounter = MaxJumpCounter;
        }
    }

    public void JumpInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_utility.IsGrounded())
            {
                _rb.velocity = new Vector2(_rb.velocity.x, JumpPower);
                _lookAction._switcher.SwitchMainCameraPriority();
            }
            else if (_jumpCounter > 0 && !_utility.IsWall())
            {
                _jumpCounter--;
                _rb.velocity = new Vector2(_rb.velocity.x, JumpPower);
            }

            _onPlayerJump.Trigger();
        }

        if (context.canceled && _rb.velocity.y > 0f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        }
    }
}
