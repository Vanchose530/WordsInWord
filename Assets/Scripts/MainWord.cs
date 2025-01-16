using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWord : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private LetterButton letterButtonPrefab;

    private List<LetterButton> letterButtons = new List<LetterButton>();

    public void ClearLetterButtons()
    {
        foreach (LetterButton button in letterButtons)
        {
            button.Clear();
        }
    }

    public void BuildNewWord(string word)
    {
        ClearWord();
        foreach(char letter in word/*.ToUpper()*/)
        {
            AddLetterButton(letter);
        }
    }

    void AddLetterButton(char letter)
    {
        var lb = Instantiate(letterButtonPrefab, this.transform);
        lb.letter = letter;
        letterButtons.Add(lb);
    }

    public void ClearWord()
    {
        foreach(LetterButton button in letterButtons)
        {
            Destroy(button.gameObject);
        }
        letterButtons.Clear();
    }
}
