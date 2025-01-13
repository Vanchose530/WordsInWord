using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuessedWord : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private TextMeshProUGUI wordTMP;

    public string word
    {
        get { return wordTMP.text; }
        set { wordTMP.text = value.ToUpper(); }
    }
}
