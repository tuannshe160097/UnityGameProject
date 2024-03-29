using Script.SceneManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Script.Environment
{

    public class Gate : MonoBehaviour
    {
        public string Scene;
        public Vector3 Coordinate;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                ChangeSceneManager.ChangeScene(Scene, Coordinate);
            }
        }
    }

}