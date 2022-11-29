using MoreMountains.Feedbacks;
using UnityEngine;

namespace QuestUp
{
    public class JuicinessManager : MonoBehaviour
    {
        public static JuicinessManager Instance { get; private set; }

        [field:SerializeField] public MMF_Player ScreenShake { get; private set; }
        [field:SerializeField] public MMF_Player ParticleEffects { get; private set; }

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
    }
}
