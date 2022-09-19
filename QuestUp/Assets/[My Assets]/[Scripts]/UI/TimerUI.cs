using UnityEngine;
using TMPro;

namespace QuestUp
{
    public class TimerUI : MonoBehaviour
    {
        private TMP_Text _text = null;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update() // TODO: This should be triggered by an event in LevelManager
        {
            _text.text = LevelController.Instance.TimeLeft.ToString();
        }
    }
}
