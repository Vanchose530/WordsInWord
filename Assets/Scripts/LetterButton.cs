using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterButton : MonoBehaviour
{
    [Header("Letter")]
    [SerializeField] private char letter = 'A';

    [Header("Setup")]
    [SerializeField] private TextMeshProUGUI letterTMP;
    [SerializeField] private Animator animator;

    const string ENABLE_ANIMATOR_WORD = "Enable";
    const string DISABLE_ANIMATOR_WORD = "Disable";

    bool enableInSub;

    private void Start()
    {
        letterTMP.text = letter.ToString().ToUpper();
        animator.Play(DISABLE_ANIMATOR_WORD);
        enableInSub = false;
    }

    public void Click()
    {
        if (enableInSub)
        {
            DisableFromSum();
        }
        else
        {
            EnableInSub();
        }
    }

    void EnableInSub()
    {
        animator.Play(ENABLE_ANIMATOR_WORD);
        GameManager.instance.subWord.AddLetter(letter);
        enableInSub = true;
    }

    void DisableFromSum()
    {
        animator.Play(DISABLE_ANIMATOR_WORD);
        GameManager.instance.subWord.RemoveLetter(letter);
        enableInSub = false;
    }

    public void Clear()
    {
        animator.Play(DISABLE_ANIMATOR_WORD);
        enableInSub = false;
    }
}
