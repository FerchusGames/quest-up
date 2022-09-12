using System.Collections;
using System.Collections.Generic;
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

        void Update()
        {
            _text.text = "Coins: " + CoinManager.Instance.GetCoins();
        }
    }
}
