using QuestUp;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text _text = null;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        _text.text = "Score: " + GameManager.Instance.LevelCount    ;
    }
}
