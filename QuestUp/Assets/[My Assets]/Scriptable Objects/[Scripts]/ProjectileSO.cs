using UnityEngine;

namespace QuestUp
{
    [CreateAssetMenu(fileName = "Projectile", menuName = "ScriptableObjects/ProjectileSO")]
    public class ProjectileSO : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float EffectDuration { get; private set; }
        [field: SerializeField] public float KnockbackOnShoot { get; private set; }
        [field: SerializeField] public float KnockbackOnHit { get; private set; }
    }
}
