using UnityEngine;

namespace QuestUp
{
    public class MainMenuController : MonoBehaviour
    {
        public void GoToFirstLevel()
        {
            TransitionManager.Instance.NextLevel("Level1");
        }
    }
}
