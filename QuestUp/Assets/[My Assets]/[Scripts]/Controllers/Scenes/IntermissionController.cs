using QuestUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermissionController : MonoBehaviour
{
    public void GoToNextLevel()
    {
        TransitionManager.Instance.NextLevel("Level1");
    }
}
