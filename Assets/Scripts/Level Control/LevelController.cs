using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int currentLevel { get; private set; }

    private LevelDataHandler _levelDataHandler;
    public LevelDataHandler levelDataHandler
    {
        get
        {
            if (_levelDataHandler == null)
            {
                _levelDataHandler = CreateLevelDataHandler();
            }
            return _levelDataHandler;
        }
    }

    public bool previousLeveExists { get { return levelDataHandler.IsLevelExists(currentLevel - 1); } }
    public bool nextLeveExists { get { return levelDataHandler.IsLevelExists(currentLevel + 1); } }

    const string LEVEL_FOLDER_NAME = "Levels";
    const string LEVEL_FILE_NAME = "level";

    LevelDataHandler CreateLevelDataHandler()
    {
        string fullPathToDir = Path.Combine(Application.dataPath, LEVEL_FOLDER_NAME);
        return new LevelDataHandler(fullPathToDir, LEVEL_FILE_NAME);
    }

    public Level Previous()
    {
        currentLevel--;
        return levelDataHandler.GetLevel(currentLevel);
    }

    public Level Next()
    {
        currentLevel++;
        return levelDataHandler.GetLevel(currentLevel);
    }

    public Level Concrete(int level)
    {
        currentLevel = level;
        return levelDataHandler.GetLevel(currentLevel);
    }
}
