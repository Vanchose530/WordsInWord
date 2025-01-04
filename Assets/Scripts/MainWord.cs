using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWord : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private List<LetterButton> letterButtons;

    public void ClearLetterButtons()
    {
        foreach (LetterButton button in letterButtons)
        {
            button.Clear();
        }
    }
}
