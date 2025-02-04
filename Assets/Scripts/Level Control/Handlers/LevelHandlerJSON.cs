using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Profiling;

public class LevelHandlerJSON : LevelHandler
{
    const string LEVEL_FILE_FORMAT = ".json";

    public LevelHandlerJSON(string levelDirPath, string levelFileName) : base(levelDirPath, levelFileName)
    {
        Debug.Log("Created new Level Handler JSON with "
            + levelDirPath + " level direction path and "
            + levelFileName + " level file name.");
    }

    public override Level GetLevel(int levelId)
    {
        string levelFullName = levelFileName + levelId.ToString() + LEVEL_FILE_FORMAT;
        string fullPath = Path.Combine(levelDirPath, levelFullName);

        Level loadedLevel = new Level();

        if (File.Exists(fullPath))
        {
            try
            {
                string levelToLoad;

                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        levelToLoad = reader.ReadToEnd();
                    }
                }

                loadedLevel = JsonUtility.FromJson<Level>(levelToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e);
            }
        }
        
        return loadedLevel;
    }

    public override bool IsLevelExists(int levelId)
    {
        string levelFullName = levelFileName + levelId.ToString() + LEVEL_FILE_FORMAT;
        string fullPath = Path.Combine(levelDirPath, levelFullName);
        return File.Exists(fullPath);
    }

    public void GenerateLevelTemplate()
    {
        string templateName = "template.json";
        string fullPath = Path.Combine(levelDirPath, templateName);

        if (!File.Exists(fullPath))
        {
            Level template = new Level();

            template.word = "шаблон";

            template.subwords.Add("один");
            template.subwords.Add("два");
            template.subwords.Add("три");

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

                string dataToStore = JsonUtility.ToJson(template, true);

                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(dataToStore);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
            }
        }
        else
        {
            Debug.Log("Template level file already exists. Dont need to create a new one.");
        }
        
    }
}
