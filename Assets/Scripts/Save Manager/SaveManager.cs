using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class SaveManager : MonoBehaviour
{
    protected static string SaveSlot;
    protected abstract string SaveFilePath { get; }

    [SerializeField]
    protected SubjectOneParam OnSave;
    [SerializeField]
    protected SubjectOneParam OnLoad;

    public void ChangeSaveSlot(string saveSlot)
    {
        SaveSlot = saveSlot;
    }

    public void Save()
    {
        Dictionary<string, object> saveData = new Dictionary<string, object>();
        OnSave.Trigger(saveData);
        ToFile(saveData);
    }

    protected void ToFile(Dictionary<string, object> saveData)
    {
        string json = JsonConvert.SerializeObject(saveData, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
        });
        new FileInfo(SaveFilePath).Directory.Create();
        File.WriteAllText(SaveFilePath, json);
    }

    public void Load()
    {
        Dictionary<string, object> loadData = FromFile();
        OnLoad.Trigger(loadData);
    }

    protected Dictionary<string, object> FromFile()
    {
        string data = File.ReadAllText(SaveFilePath);
        return JsonConvert.DeserializeObject<Dictionary<string, object>>(data, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
        });
    }
}
