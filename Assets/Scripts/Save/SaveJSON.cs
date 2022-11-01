using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveJSON 
{
    private readonly string _filePath;

    public SaveJSON()
    {
        _filePath = Application.persistentDataPath + "/Save.json";
    }
    public void Save(SaveData data)
    {
        var json = JsonUtility.ToJson(data);
        using (var writer = new StreamWriter(_filePath))
        {
            writer.WriteLine(Base64.Encode(json));
        }
    }
    public SaveData Load()
    {
        if (!File.Exists(_filePath))
        {
            return new SaveData();
        }
        string json = "";
        using (var reader = new StreamReader(_filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                json += line;
            }
            if (string.IsNullOrEmpty(json))
            {
                return new SaveData();
            }
            return JsonUtility.FromJson<SaveData>(Base64.Decode(json));
        }
    }
}
