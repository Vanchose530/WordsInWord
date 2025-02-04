using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "level", menuName = "Scriptable Objects/Level", order = 1)]
public class LevelSO : ScriptableObject
{
    public string word;

    public List<string> subwords;

    public Level GetLevel()
    {
        return new Level(word, subwords);
    }
}
