namespace Script.Cinemachine
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Cinemachine;

    public class CinemachineSwitcher : MonoBehaviour
    {
        private CinemachineUtility _utility;

        void Start()
        {
            _utility = GetComponent<CinemachineUtility>();
        }

        public void SwitchUpCameraPriority()
        {
            _utility.VirtualMainCamera.Priority = 0;
            _utility.VirtualUpCamera.Priority = 10;
            _utility.VirtualDownCamera.Priority = 0;
        }
        public void SwitchDownCameraPriority()
        {
            _utility.VirtualMainCamera.Priority = 0;
            _utility.VirtualUpCamera.Priority = 0;
            _utility.VirtualDownCamera.Priority = 10;
        }
        public void SwitchMainCameraPriority()
        {
            _utility.VirtualMainCamera.Priority = 10;
            _utility.VirtualUpCamera.Priority = 0;
            _utility.VirtualDownCamera.Priority = 0;
        }
    }
}