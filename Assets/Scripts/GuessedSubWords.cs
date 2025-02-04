using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuessedSubWords : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private GuessedWord guessedWordPrefab;

    public void AddNewWord(string word)
    {
        var gw = Instantiate(guessedWordPrefab, this.transform);
        gw.word = word;
    }

    public void ClearSubWords()
    {
        GuessedWord[] words = GetComponentsInChildren<GuessedWord>();

        foreach (GuessedWord w in words)
        {
            Destroy(w.gameObject);
        }
    }
}
