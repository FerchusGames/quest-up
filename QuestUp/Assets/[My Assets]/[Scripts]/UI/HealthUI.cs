using UnityEngine;
using TMPro;

namespace QuestUp
{
    public class HealthUI : MonoBehaviour
    {
        private TMP_Text _text = null;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
        }

        void Update() // TODO: This should be triggered by an event in HealthManager
        {
            _text.text = "Health: " + HealthManager.Instance.CurrentHealth;
        }
    }
}
