using UnityEngine;

namespace QuestUp
{
    public class MainMenuController : MonoBehaviour
    {
        public void GoToFirstLevel()
        {
            TransitionManager.Instance.TransitionToNextLevel("Level");
        }
    }
}
