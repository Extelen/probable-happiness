using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public static class SaveSystem
{
    // Enums
    public enum LoadInfo { Loaded, Created }

    // Methods
    /// <summary>
    /// Save data on a file.
    /// </summary>
    public static void Save(object data, string fileName)
    {
        string jsonString = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + $"/{fileName}.json", jsonString);
    }


    /// <summary>
    /// Load or create a new file data.
    /// </summary>
    public static LoadInfo LoadOrCreate<T>(string fileName, out T data) where T : new()
    {
        data = new T();

        if (GetIfFileExists(fileName))
        {
            string raw = File.ReadAllText(Application.persistentDataPath + $"/{fileName}.json");
            JsonUtility.FromJsonOverwrite(raw, data);

            return LoadInfo.Loaded;
        }

        return LoadInfo.Created;
    }

    /// <summary>
    /// Get if the file in the application persistent data path exists.
    /// </summary>
    /// <returns></returns>
    public static bool GetIfFileExists(string fileName)
    {
        if (File.Exists(Application.persistentDataPath + $"/{fileName}.json")) return true;
        return false;
    }
}