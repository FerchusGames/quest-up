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
    }
}
