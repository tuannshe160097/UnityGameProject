namespace Script.SaveManager
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    public class SceneSave : SaveManager
    {
        protected override string SaveFilePath => Application.persistentDataPath + "/" + SaveSlot + "/" + SceneManager.GetActiveScene().name + ".json";

        private void Start()
        {
            SceneManager.sceneLoaded += SceneChangeLoadData;
        }

        private void SceneChangeLoadData(Scene scene, LoadSceneMode mode)
        {
            if (!File.Exists(SaveFilePath))
            {
                ToFile(new Dictionary<string, object>());
            }

            Load();
        }
    }

}