using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelHandlerSO : LevelHandler
{
    public LevelHandlerSO(string levelDirPath, string levelFileName) : base(levelDirPath, levelFileName)
    {
        Debug.Log("Created new Level Handler SO with "
            + levelDirPath + " level direction path and "
            + levelFileName + " level file name.");
    }

    public override Level GetLevel(int levelId)
    {
        string fullLevelFileName = levelFileName + levelId;
        string fullPath = Path.Combine(levelDirPath, fullLevelFileName);

        LevelSO levelSO = Resources.Load<LevelSO>(fullPath);

        if (levelSO != null)
        {
            return levelSO.GetLevel();
        }
        else
        {
            return null;
        }
    }

    public override bool IsLevelExists(int levelId)
    {
        string fullLevelFileName = levelFileName + levelId;
        string fullPath = Path.Combine(levelDirPath, fullLevelFileName);

        return Resources.Load<LevelSO>(fullPath) != null;
    }
}
