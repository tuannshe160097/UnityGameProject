using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    [SerializeField]
    private string Scene;
    [SerializeField]
    private Vector3 Coordinate;

    private static string _scene;
    private static Vector3 _coordinate;

    [SerializeField]
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _scene = Scene;
        _coordinate = Coordinate;

        ChangeScene(Scene, Coordinate);
        SceneManager.sceneLoaded += RepositionPlayer;
    }

    public static void ChangeScene(string Scene, Vector3 Coordinate)
    {
        _scene = Scene;
        _coordinate = Coordinate;

        SceneManager.LoadScene(_scene);
    }

    private void RepositionPlayer(Scene scene, LoadSceneMode mode)
    {
        _player.transform.position = _coordinate;
    }
}
