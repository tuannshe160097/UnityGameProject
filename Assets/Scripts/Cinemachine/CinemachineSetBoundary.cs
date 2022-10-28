namespace Script.Cinemachine
{
    using global::Cinemachine;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class CinemachineSetBoundary : MonoBehaviour
    {
        private CinemachineUtility _utility;
        private CinemachineConfiner2D _mainConfiner;
        private CinemachineConfiner2D _upConfiner;
        private CinemachineConfiner2D _downConfiner;

        void Start()
        {
            _utility = GetComponent<CinemachineUtility>();
            _mainConfiner = _utility.VirtualMainCamera.GetComponent<CinemachineConfiner2D>();
            _upConfiner = _utility.VirtualUpCamera.GetComponent<CinemachineConfiner2D>();
            _downConfiner = _utility.VirtualDownCamera.GetComponent<CinemachineConfiner2D>();

            SceneManager.sceneLoaded += SetBoundary;
        }

        private void SetBoundary(Scene scene, LoadSceneMode mode)
        {
            _mainConfiner.m_BoundingShape2D = GameObject.FindWithTag("CameraBoundary")?.GetComponent<PolygonCollider2D>();
            _upConfiner.m_BoundingShape2D = GameObject.FindWithTag("CameraBoundary")?.GetComponent<PolygonCollider2D>();
            _downConfiner.m_BoundingShape2D = GameObject.FindWithTag("CameraBoundary")?.GetComponent<PolygonCollider2D>();
        }
    }

}