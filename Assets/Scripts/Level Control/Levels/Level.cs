using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public string word;

    public List <string> subwords;

    public Level()
    {
        subwords = new List <string>();
    }

    public Level(string word, List<string> subwords)
    {
        this.word = word;
        this.subwords = subwords;
    }
}
