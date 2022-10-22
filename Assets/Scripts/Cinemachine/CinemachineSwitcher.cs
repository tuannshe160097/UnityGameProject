using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _virtualMainCamera;
    [SerializeField]
    private CinemachineVirtualCamera _virtualUpCamera;
    [SerializeField]
    private CinemachineVirtualCamera _virtualDownCamera;

    public void SwitchUpCameraPriority()
    {
        _virtualMainCamera.Priority = 0;
        _virtualUpCamera.Priority = 10;
        _virtualDownCamera.Priority = 0;
    }
    public void SwitchDownCameraPriority()
    {
        _virtualMainCamera.Priority = 0;
        _virtualUpCamera.Priority = 0;
        _virtualDownCamera.Priority = 10;
    }
    public void SwitchMainCameraPriority()
    {
        _virtualMainCamera.Priority = 10;
        _virtualUpCamera.Priority = 0;
        _virtualDownCamera.Priority = 0;
    }
}
