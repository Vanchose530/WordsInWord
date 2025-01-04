using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("Find more than one GameManager script in scene!");

        guessedSubWordsList = new List<string>();
    }

    void SetupGame()
    {

    }

    public void CheckSubWord()
    {
        if (guessedSubWordsList.Contains(subWord.word))
        {
            Debug.Log("����� ��� ��������!");
        }
        else if (allSubWords.Contains(subWord.word))
        {
            Debug.Log("������ �����!");
            guessedSubWordsList.Add(subWord.word);
        }
        else
        {
            Debug.Log("�������� �����!");
        }

        subWord.ClearSubWord();
        mainWord.ClearLetterButtons();
        guessedSubWords.DisplayWords(guessedSubWordsList);
    }
}
