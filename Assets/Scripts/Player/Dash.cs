using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    public int DashSpeed;
    public int MaxDashCounter;

    private int _dashCounter;

    private Utility _utility;
    private Rigidbody2D _rb;

    [SerializeField]
    private Subject _onPlayerDash;

    // Start is called before the first frame update
    void Start()
    {
        _utility = GetComponent<Utility>();
        _rb = GetComponent<Rigidbody2D>();
        _dashCounter = MaxDashCounter;
    }

    // Update is called once per frame
    void Update()
    {
        if (_dashCounter == 0 && _utility.MovementResetable())
        {
            _dashCounter = MaxDashCounter;
        }
    }

    public void DashInput(InputAction.CallbackContext context)
    {

        if (context.started && _utility.CanMove && _dashCounter > 0)
        {
            _utility.CanMove = false;
            _utility.CanAttack = false;
            _dashCounter--;
            _rb.velocity = new Vector2(3 * DashSpeed * _utility.DirectionModifier(), _rb.velocity.y);
            _rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            _onPlayerDash.Trigger();

            Invoke("stopDash", 0.2f);
        }
    }

    private void stopDash()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        _utility.CanMove = true;
        _utility.CanAttack = true;
    }
}
