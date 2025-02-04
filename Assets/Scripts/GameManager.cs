using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [Header("Game")]
    [SerializeField] private string word;
    [SerializeField] private List<string> allSubWords;
    private List<string> guessedSubWordsList;

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
        }
        else
        {
            // Debug.Log("Неверное слово!");
        }

        subWord.ClearSubWord();
        mainWord.ClearLetterButtons();
    }
}
