using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerSave : SaveManager
{
    protected override string SaveFilePath => Application.persistentDataPath + "/" + SaveSlot + "/player.json";

    private Dictionary<string, object> DefaultData;

    private void Start()
    {
        DefaultData = new Dictionary<string, object>();
        DefaultData.Add("Scene", "Demo 1");
        DefaultData.Add("Position", new Vector3Json(-8, -0.3f, 0));
    }

    public void CreateSave(string saveSlot)
    {
        ChangeSaveSlot(saveSlot);

        if (!File.Exists(SaveFilePath))
        {
            new FileInfo(SaveFilePath).Directory.Create();
            ToFile(DefaultData);
        }
    }
}
