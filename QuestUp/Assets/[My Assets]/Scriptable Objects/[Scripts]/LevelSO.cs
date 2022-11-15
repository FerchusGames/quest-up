using UnityEngine;

namespace QuestUp
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelSO")]
    public class LevelSO : ScriptableObject
    {
        [field: SerializeField] public int InitialLevel { get; private set; }
        [field: SerializeField] public int LastLevel { get; private set; }

        [field:SerializeField] public int HazardAmount { get; private set; }

        [field: SerializeField] public float SpeedMinMultiplier { get; private set; }
        [field: SerializeField] public float SpeedMaxMultiplier { get; private set; }

        [field: SerializeField] public float CountMinMultiplier { get; private set; }
        [field: SerializeField] public float CountMaxMultiplier { get; private set; }

        [field: SerializeField] public float RateMinMultiplier { get; private set; }
        [field: SerializeField] public float RateMaxMultiplier { get; private set; }
    }
}
