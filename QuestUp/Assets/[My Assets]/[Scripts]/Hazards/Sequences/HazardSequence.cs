using System.Collections;
using UnityEngine;

namespace QuestUp
{
    public abstract class HazardSequence : MonoBehaviour
    {
        [SerializeField] protected GameObject _hazard = null;

        protected virtual void Start()
        {
            InitializeValues();
            StartCoroutine(Sequence());
        }

        protected abstract void InitializeValues();

        protected abstract GameObject Spawn();

        public abstract void Despawn();

        protected abstract IEnumerator Sequence();
    }
}
