using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float Speed;
    private Utility _utility;
    private Rigidbody2D _rb;
    private Look _lookAction;

    [SerializeField]
    private Subject _onPlayerMove;

    // Start is called before the first frame update
    void Start()
    {
        _utility = GetComponent<Utility>();
        _rb = GetComponent<Rigidbody2D>();
        _lookAction = GetComponent<Look>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_utility.MoveDirection != 0 && _utility.CanMove)
        {
            _rb.velocity = new Vector2(_utility.MoveDirection * Speed, _rb.velocity.y);
        }
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        _utility.MoveDirection = context.ReadValue<float>();

        if (context.started)
        {
            _onPlayerMove.Trigger();
            _lookAction._switcher.SwitchMainCameraPriority();
        }

        if (context.canceled)
        {
            _utility.CanLook = true;
            StopMovement();
        }
    }

    public void StopMovement()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
    }
}
