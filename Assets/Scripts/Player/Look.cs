using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Look : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LookUpInput(InputAction.CallbackContext context)
    {

        if (context.performed)
        {

        }
        if (context.canceled)
        {

        }
    }

    public void LookDownInput(InputAction.CallbackContext context)
    {

        if (context.performed)
        {

        }
        if (context.canceled)
        {

        }
    }
}
