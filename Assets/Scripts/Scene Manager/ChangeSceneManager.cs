using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    private static string _scene;
    private static Vector3 _coordinate;

    [SerializeField]
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSave save = FindObjectOfType<PlayerSave>();
        save.CreateSave("0");
        save.Load();

        ChangeScene(_scene, _coordinate);
        SceneManager.sceneLoaded += RepositionPlayer;
    }

    public static void ChangeScene(string scene, Vector3 coordinate)
    {
        _scene = scene;
        _coordinate = coordinate;

        SceneManager.LoadScene(_scene);
    }

    private void RepositionPlayer(Scene scene, LoadSceneMode mode)
    {
        _player.transform.position = _coordinate;
    }

    public void Load(object param)
    {
        Dictionary<string, object> loadData = (Dictionary<string, object>)param;
        _scene = (string)loadData["Scene"];
        _coordinate = ((Vector3Json)loadData["Position"]).ToVector3();
    }
}