using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
public class JsonFilehandler : MonoBehaviour
{
    public void SaveToJson<T>(List<T> toSave, string fileName)
    {
        string content = "";
        WriteFile(GetPath(fileName), content);
    }

    public void ReadFromJson()
    {

    }

    private string GetPath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;

    }

    private void WriteFile(string path, string content)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(content);
        }
    }

    private string ReadFile()
    {
        return "";
    }
}

/*public static class JsonHelper
{
    public static T[] FromJson<T> (string json)
    {
        Wrapper<T>
        
    }
}*/
