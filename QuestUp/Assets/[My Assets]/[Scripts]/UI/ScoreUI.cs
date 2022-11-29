using TMPro;
using UnityEngine;

namespace QuestUp
{
    public class ScoreUI : MonoBehaviour
    {
        private TMP_Text _text = null;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
        }

        void Update()
        {
            _text.text = "Score: " + GameManager.Instance.LevelCount;
        }
    }
}
