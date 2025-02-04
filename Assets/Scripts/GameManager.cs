using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private List<string> allSubWords;
    private List<string> guessedSubWordsList;

    private Saver _saver;
    private Saver saver
    {
        get
        {
            if (_saver == null)
                _saver = new Saver();
            return _saver;
        }
    }

    [Header("Setup")]
    [SerializeField] private SubWord _subWord;
    public SubWord subWord { get { return _subWord; } }

    [SerializeField] private MainWord _mainWord;
    public MainWord mainWord { get { return _mainWord; } }

    [SerializeField] private GuessedSubWords _guessedSubWords;
    public GuessedSubWords guessedSubWords { get { return _guessedSubWords; } }

    [SerializeField] private LevelController _levelController;
    public LevelController levelController { get { return _levelController; } }

    [SerializeField] private HeaderPanel headerPanel;

    public int wordsRemain { get { return allSubWords.Count - guessedSubWordsList.Count; } }

    private int _starsCount;
    public int starsCount
    {
        get { return _starsCount; }
        set
        {
            headerPanel.SetStarsCount(value);
            saver.SetStarsCount(value);
            _starsCount = value;
        }
    }

    const int STARS_REWARD = 5;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("Find more than one GameManager script in scene!");

        guessedSubWordsList = new List<string>();
    }

    private void Start()
    {
        saver.ClearSave();

        starsCount = saver.GetStarsCount();
        SetupLevel(levelController.Concrete(1));

        // levelController.levelDataHandler.GenerateLevelTemplate();
    }

    public void ToNextLevel()
    {
        SetupLevel(levelController.Next());
    }

    public void ToPreviousLevel()
    {
        SetupLevel(levelController.Previous());
    }

    void SetupLevel(Level level)
    {
        mainWord.BuildNewWord(level.word);
        allSubWords = level.subwords;

        guessedSubWordsList.Clear();
        guessedSubWords.ClearSubWords();

        var guessedSW = saver.GetGuessedSubWords(level.word);
        if (guessedSW != null)
        {
            foreach (var word in guessedSW)
            {
                guessedSubWordsList.Add(word);
                guessedSubWords.AddNewWord(word);
            }
        }

        headerPanel.SetWordsRemain(wordsRemain);
        headerPanel.SetLevel(levelController.currentLevel);
    }

    void AddNewGuessedWord(string word)
    {
        guessedSubWordsList.Add(word);
        guessedSubWords.AddNewWord(word);
        headerPanel.SetWordsRemain(wordsRemain);
    }

    public void CheckSubWord()
    {
        if (guessedSubWordsList.Contains(subWord.word))
        {
            // Debug.Log("Слово уже отгадано!");
        }
        else if (allSubWords.Contains(subWord.word))
        {
            // Debug.Log("Верное слово!");
            AddNewGuessedWord(subWord.word);
            saver.AddGuessedSubWord(mainWord.word, subWord.word);
            starsCount += STARS_REWARD;
        }
        else
        {
            // Debug.Log("Неверное слово!");
        }

        subWord.ClearSubWord();
        mainWord.ClearLetterButtons();
    }
}
