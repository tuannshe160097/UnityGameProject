using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WallClimb : MonoBehaviour
{
    public float WallEjectPowerX;
    public float WallEjectPowerY;
    public float WallDrag;

    private Utility _utility;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _utility = GetComponent<Utility>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_utility.IsGrounded() && _utility.IsWall() && _rb.velocity.y < 0)     
        {
            _rb.drag = WallDrag;
        }
        else
        {
            _rb.drag = 0;
        }
    }

    public void WallJumpInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_utility.IsWall() && !_utility.IsGrounded())
            {
                _utility.CanMove = false;
                _utility.CanAttack = false;
                _rb.velocity = new Vector2(WallEjectPowerX * _utility.DirectionModifier() * -1, WallEjectPowerY);
                Invoke("stopWallEject", 0.2f);
            }
        }
    }

    private void stopWallEject()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        _utility.CanMove = true;
        _utility.CanAttack = true;
    }
}
