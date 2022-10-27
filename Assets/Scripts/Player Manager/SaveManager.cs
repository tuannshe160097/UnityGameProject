using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static SubjectOneParam _onSave;
    private static SubjectOneParam _onLoad;
    private static string _saveFilePath;

    public SubjectOneParam OnSave;
    public SubjectOneParam OnLoad;

    public void Start()
    {
        _onSave = OnSave;
        _onLoad = OnLoad;
        _saveFilePath = Application.persistentDataPath + "/Save/save1.json";
    }

    public static void Save()
    {
        Dictionary<string, object> saveData = new Dictionary<string, object>();
        _onSave.Trigger(saveData);
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
        _onLoad.Trigger(loadData);
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
