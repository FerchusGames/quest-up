using UnityEngine;
using TMPro;

namespace QuestUp
{
    public class CoinUI : MonoBehaviour
    {
        private TMP_Text _text = null;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update() // TODO: This should be triggered by an event in CoinManager
        {
            _text.text = "Coins: " + CoinManager.Instance.Coins;
        }
    }
}
