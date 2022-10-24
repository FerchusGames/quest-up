using System.Collections;
using UnityEngine;

namespace QuestUp
{
    public abstract class HazardSequence : MonoBehaviour
    {
        [SerializeField] protected GameObject _hazard = null;

        protected virtual void OnEnable()
        {
            StartCoroutine(Sequence());
        }

        protected abstract IEnumerator Sequence();
    }
}
