using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int currentLevel { get; private set; }

    private LevelHandler _levelDataHandler;
    public LevelHandler levelDataHandler
    {
        get
        {
            if (_levelDataHandler == null)
            {
                switch (levelHandlerType)
                {
                    case LevelHandlerType.ScriptableObjects:
                        _levelDataHandler = CreateLevelDataHandlerSO();
                        break;
                    case LevelHandlerType.JSON:
                        _levelDataHandler = CreateLevelDataHandlerJSON();
                        break;
                    default:
                        Debug.LogError("Raw level handler type: " + levelHandlerType);
                        break;
                }
            }
            return _levelDataHandler;
        }
    }

    [Header("Level Handling")]
    [SerializeField] private LevelHandlerType levelHandlerType;

    [Header("Data path TMP")]
    [SerializeField] private TextMeshProUGUI dataPathTMP;
    [SerializeField] private bool showDataPathTMP;

    public bool previousLeveExists { get { return levelDataHandler.IsLevelExists(currentLevel - 1); } }
    public bool nextLeveExists { get { return levelDataHandler.IsLevelExists(currentLevel + 1); } }

    const string LEVEL_FOLDER_NAME = "Levels";
    const string LEVEL_FILE_NAME = "level";

    private void Start()
    {
        if (!showDataPathTMP && dataPathTMP != null)
        {
            Destroy(dataPathTMP.gameObject);
        }
    }

    LevelHandlerSO CreateLevelDataHandlerSO()
    {
        return new LevelHandlerSO(LEVEL_FOLDER_NAME, LEVEL_FILE_NAME);
    }

    LevelHandlerJSON CreateLevelDataHandlerJSON()
    {
        string fullPathToDir = "";

        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            fullPathToDir = LEVEL_FOLDER_NAME;
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            fullPathToDir = Path.Combine(Application.dataPath, LEVEL_FOLDER_NAME);
        }
        else
        {
            Debug.LogError("Unknown runtime platform: " + Application.platform);
            fullPathToDir = "Unknown runtime platform: " + Application.platform;
        }

        if (dataPathTMP != null)
            dataPathTMP.text = fullPathToDir;

        return new LevelHandlerJSON(fullPathToDir, LEVEL_FILE_NAME);
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
