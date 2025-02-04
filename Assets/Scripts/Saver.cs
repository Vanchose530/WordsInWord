using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver
{
    const string SUB_WORDS_SEPARATOR = ", ";
    const string STARS_COUNT_KEY = "Stars Count";

    public void ClearSave() => PlayerPrefs.DeleteAll();

    public void SetStarsCount(int count)
    {
        PlayerPrefs.SetInt(STARS_COUNT_KEY, count);
    }

    public int GetStarsCount()
    {
        if (PlayerPrefs.HasKey(STARS_COUNT_KEY))
            return PlayerPrefs.GetInt(STARS_COUNT_KEY);
        return 0;
    }

    public void AddGuessedSubWord(string mainWord, string newSubWord)
    {
        if (PlayerPrefs.HasKey(mainWord))
        {
            string subWords = PlayerPrefs.GetString(mainWord);
            subWords += SUB_WORDS_SEPARATOR;
            subWords += newSubWord;
            PlayerPrefs.SetString(mainWord, subWords);
        }
        else
        {
            PlayerPrefs.SetString(mainWord, newSubWord);
        }
    }

    public string[] GetGuessedSubWords(string mainWord)
    {
        if (PlayerPrefs.HasKey(mainWord))
        {
            string subWords = PlayerPrefs.GetString(mainWord);
            return subWords.Split(SUB_WORDS_SEPARATOR);
        }
        else
        {
            return null;
        }
    }
}
