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
    [SerializeField] private TextMeshProUGUI wordsRemainTMP;

    public int wordsRemain { get { return allSubWords.Count - guessedSubWordsList.Count; } }

    const string WORDS_REMAIN_STRING = "Осталось слов: ";
    const string ALL_WORDS_GUESSED_STRING = "Все слова отгаданы!";

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("Find more than one GameManager script in scene!");

        guessedSubWordsList = new List<string>();
        UpdateWordsRemainUI();
    }

    void SetupGame()
    {

    }

    void AddNewGuessedWord(string word)
    {
        guessedSubWordsList.Add(word);
        guessedSubWords.AddNewWord(word);
        UpdateWordsRemainUI();
    }

    void UpdateWordsRemainUI()
    {
        if (wordsRemain > 0)
        {
            wordsRemainTMP.text = WORDS_REMAIN_STRING + wordsRemain;
        }
        else
        {
            wordsRemainTMP.text = ALL_WORDS_GUESSED_STRING;
        }
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
