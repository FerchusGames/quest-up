using QuestUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class ManagerInstanceDestroyer : MonoBehaviour
    {
        private void Awake()
        {
            DestroyManagerInstance(HealthManager.Instance.gameObject);
            DestroyManagerInstance(CoinManager.Instance.gameObject);
            DestroyManagerInstance(GameManager.Instance.gameObject);
        }

        private void DestroyManagerInstance(GameObject gameObject)
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
