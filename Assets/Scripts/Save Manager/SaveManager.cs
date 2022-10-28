using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class SaveManager : MonoBehaviour
{
    private SubjectOneParam OnSave;
    private SubjectOneParam OnLoad;
    private string SaveFilePath;

    public static void Save()
    {
        Dictionary<string, object> saveData = new Dictionary<string, object>();
        OnSave.Trigger(saveData);
        ToFile(saveData);
    }

    private static void ToFile(Dictionary<string, object> saveData)
    {
        string json = JsonConvert.SerializeObject(saveData, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
        }); 
        new FileInfo(_saveFilePath).Directory.Create();
        File.WriteAllText(_saveFilePath, json);
    }

    public static void Load()
    {
        Dictionary<string, object> loadData = FromFile();
        OnLoad.Trigger(loadData);
    }

    private static Dictionary<string, object> FromFile()
    {
        string data = File.ReadAllText(_saveFilePath);
        return JsonConvert.DeserializeObject<Dictionary<string, object>>(data, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
        });
    }
}
