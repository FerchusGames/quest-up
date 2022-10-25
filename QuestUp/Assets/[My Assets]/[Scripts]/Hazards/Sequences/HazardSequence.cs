using System.Collections;
using UnityEngine;

namespace QuestUp
{
    public abstract class HazardSequence : MonoBehaviour
    {
        [SerializeField] protected GameObject _hazard = null;

        protected virtual void Start()
        {
            StartCoroutine(Sequence());
        }

        protected abstract GameObject Spawn();

        protected abstract IEnumerator Sequence();
    }
}
