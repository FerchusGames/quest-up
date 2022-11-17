using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class NukeSequence : HazardSequence
    {
        private GameObject[] _nukes;

        [SerializeField] private int _nukeCount;
        [SerializeField] private float _nukeInterval;
        [SerializeField] private float _areaBorderX;
        [SerializeField] private float _areaBorderY;

        protected override void InitializeValues()
        {
            _nukeCount = (int)(_nukeCount * HazardManager.Instance.CountMultiplier);
            _nukeInterval /= HazardManager.Instance.RateMultiplier;
        }

        protected override IEnumerator Sequence()
        {
            while(true)
            {
                _nukes = new GameObject[_nukeCount];

                for (int i = 0; i < _nukeCount; i++)
                {
                    _nukes[i] = Spawn();

                    if (i != 0)
                    {
                        _nukes[i].GetComponent<AudioEvent>()?.Disable();
                    }
                }
                yield return new WaitForSeconds(_nukeInterval);
            }
        }

        protected override GameObject Spawn()
        {
            return Instantiate(_hazard, GetSpawnPosition(), Quaternion.identity);
        }

        public override void Despawn()
        {
            foreach (GameObject nuke in _nukes)
            {
                Destroy(nuke);
            }
            Destroy(gameObject);
        }

        protected Vector2 GetSpawnPosition()
        {
            return new Vector2(Random.Range(-_areaBorderX, _areaBorderX), Random.Range(-_areaBorderY, _areaBorderY));

        }
    }
}
