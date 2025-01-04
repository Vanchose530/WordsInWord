using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuessedSubWords : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private TextMeshProUGUI wordsTMP;

    private void Start()
    {
        wordsTMP.text = "";
    }

    public void DisplayWords(List<string> words)
    {
        wordsTMP.text = "";

        foreach (string word in words)
        {
            wordsTMP.text += word.ToUpper();
            wordsTMP.text += "\n";
        }
    }
}
