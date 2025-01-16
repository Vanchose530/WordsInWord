using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class HeaderPanel : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI starsCountTMP;
    [SerializeField] private TextMeshProUGUI currentLevelTMP;
    [SerializeField] private TextMeshProUGUI wordsRemainTMP;

    [Header("Buttons")]
    [SerializeField] private GameObject previousLevelButtonGO;
    [SerializeField] private GameObject nextLevelButtonGO;

    const string WORDS_REMAIN_STRING = "Осталось слов: ";
    const string ALL_WORDS_GUESSED_STRING = "Все слова отгаданы!";
    const string LEVEL_STRING = "УРОВЕНЬ ";

    // --- Методы для обновления UI ---
    public void SetWordsRemain(int wordsRemain)
    {
        if (wordsRemain > 0)
        {
            wordsRemainTMP.text = WORDS_REMAIN_STRING + wordsRemain.ToString();
        }
        else
        {
            wordsRemainTMP.text = ALL_WORDS_GUESSED_STRING;
        }
    }

    public void SetLevel(int level)
    {
        currentLevelTMP.text = LEVEL_STRING + level.ToString();

        previousLevelButtonGO.SetActive(GameManager.instance.levelController.previousLeveExists);
        nextLevelButtonGO.SetActive(GameManager.instance.levelController.nextLeveExists);
    }

    public void SetStarsCount(int count)
    {
        starsCountTMP.text = count.ToString();
    }
}
