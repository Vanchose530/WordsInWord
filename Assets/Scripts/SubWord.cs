using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubWord : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private TextMeshProUGUI subWordTMP;

    public string word { get; private set; }

    private void Start()
    {
        ClearSubWord();
    }

    public void AddLetter(char letter)
    {
        word += letter;
        UpdateTMP();
    }

    public void RemoveLetter(char letter)
    {
        for (int i = word.Length - 1; i >= 0; i--)
        {
            if (word[i] == letter)
            {
                word = word.Remove(i, 1);
                UpdateTMP();
                return;
            }
        }
        Debug.LogWarning("Cant find letter to remove in Sub Word. Letter: " + letter);
    }

    public void ClearSubWord()
    {
        word = "";
        UpdateTMP();
    }

    private void UpdateTMP()
    {
        subWordTMP.text = word.ToUpper();
    }
}
