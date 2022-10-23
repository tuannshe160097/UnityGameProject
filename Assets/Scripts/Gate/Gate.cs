using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public string Scene;
    public Vector3 Coordinate;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerManager.ChangeScene(Scene, Coordinate);
        }
    }
}
