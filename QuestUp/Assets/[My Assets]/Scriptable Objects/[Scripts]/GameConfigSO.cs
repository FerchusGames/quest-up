using UnityEngine;

namespace QuestUp
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfigSO")]
    public class GameConfigSO : ScriptableObject
    {
        [field: SerializeField] public int MaxLives { get; private set; }
    }
}