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

        void Update() 
        {
            _text.text = "Health: " + HealthManager.Instance.CurrentHealth;
        }
    }
}
