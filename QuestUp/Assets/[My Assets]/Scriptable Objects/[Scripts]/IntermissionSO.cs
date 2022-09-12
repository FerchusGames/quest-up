using UnityEngine;

namespace QuestUp
{
    [CreateAssetMenu(fileName = "Intermission", menuName = "ScriptableObjects/IntermissionSO")]
    public class IntermissionSO : ScriptableObject
    {
        [field: SerializeField] public float IntermissionDuration { get; private set; }
    }
}
