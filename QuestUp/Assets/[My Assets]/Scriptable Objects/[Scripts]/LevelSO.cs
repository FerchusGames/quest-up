using UnityEngine;

namespace QuestUp
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelSO")]
    public class LevelSO : ScriptableObject
    {
        [field: SerializeField] public int LevelDuration { get; private set; }
    }
}
