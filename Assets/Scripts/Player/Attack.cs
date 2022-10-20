using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    private Utility _utility;
    private Rigidbody2D _rb;

    [SerializeField]
    private Subject _onPlayerAttack;

    // Start is called before the first frame update
    void Start()
    {
        _utility = GetComponent<Utility>();
        _rb = GetComponent<Rigidbody2D>();
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
        }

    }

    public void AttackUpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _onPlayerAttack.Trigger();
        }
    }
    public void AttackDownInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _onPlayerAttack.Trigger();
        }
    }
}
