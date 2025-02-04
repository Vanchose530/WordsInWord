using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelHandler
{
    protected string levelDirPath = "";
    protected string levelFileName = "";

    public LevelHandler(string levelDirPath, string levelFileName)
    {
        this.levelDirPath = levelDirPath;
        this.levelFileName = levelFileName;
    }

    abstract public Level GetLevel(int levelId);

    abstract public bool IsLevelExists(int levelId);
}
