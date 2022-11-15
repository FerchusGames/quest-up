using UnityEngine;

namespace QuestUp
{
    public class IntermissionController : MonoBehaviour
    {
        public void GoToNextLevel()
        {
            TransitionManager.Instance.TransitionToNextLevel("Level");
        }
    }
}
