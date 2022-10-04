using UnityEngine;

namespace QuestUp
{
    public class PrototypingHealthController : MonoBehaviour
    {
        public void PrototypingLoseHealth(int damageValue)
        {
            HealthManager.Instance.LoseHealth(damageValue);
        }
    }
}
