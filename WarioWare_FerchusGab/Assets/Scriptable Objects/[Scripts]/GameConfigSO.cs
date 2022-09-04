using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfigSO")]
public class GameConfigSO : ScriptableObject
{
    [field: SerializeField] public int maxLives { get; private set; }
}
