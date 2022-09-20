using QuestUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreenController : MonoBehaviour
{
    public void GoToMainMenu()
    {
        TransitionManager.Instance.NextLevel("MainMenu");
    }
}
