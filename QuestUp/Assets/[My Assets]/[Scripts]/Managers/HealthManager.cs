using UnityEngine;

namespace QuestUp
{
    public class HealthManager : MonoBehaviour
    {
        public static HealthManager Instance { get; private set; }

        [field: SerializeField] public int MaxHealth { get; private set; }
        [field: SerializeField] public int CurrentHealth { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            CurrentHealth = MaxHealth;
        }

        public void LoseHealth(int damage)
        {

            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth);
        }
    }
}
