using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    private InteractableObject _interactableObject = null;

    public void InteractInput(InputAction.CallbackContext context)
    {
        if (_interactableObject && context.performed)
        {
            _interactableObject.Interact();
        }
    }

    public void PrepareInteraction(InteractableObject interactableObject)
    {
        _interactableObject = interactableObject;
    }

    public void DisposeInteraction()
    {
        _interactableObject = null;
    }
}
