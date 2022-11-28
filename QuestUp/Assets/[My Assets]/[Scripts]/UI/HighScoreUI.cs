using QuestUp;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreUI : MonoBehaviour
{
    private TMP_Text _text = null;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _text.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 1);
    }
}
