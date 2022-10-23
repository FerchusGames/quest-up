using System.Collections;
using UnityEngine;

namespace QuestUp
{
    public abstract class HazardSequence : MonoBehaviour
    {
        [SerializeField] protected GameObject _hazardPrefab = null;

        public abstract IEnumerator Sequence();
    }
}
