using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Look : MonoBehaviour
{
    private CinemachineSwitcher _switcher;
    [SerializeField]
    private GameObject _cinemachineManager;
    // Start is called before the first frame update
    void Start()
    {
        _switcher = _cinemachineManager.GetComponent<CinemachineSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LookUpInput(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            _switcher.SwitchUpCameraPriority();
        }
        if (context.canceled)
        {
            _switcher.SwitchMainCameraPriority();
        }
    }

    public void LookDownInput(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            _switcher.SwitchDownCameraPriority();
        }
        if (context.canceled)
        {
            _switcher.SwitchMainCameraPriority();
        }
    }
}
