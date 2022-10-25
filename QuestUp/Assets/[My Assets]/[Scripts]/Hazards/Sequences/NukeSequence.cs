using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class NukeSequence : HazardSequence
    {
        [SerializeField] private int _nukeCount;
        [SerializeField] private float _nukeInterval;
        [SerializeField] private float _areaBorderX;
        [SerializeField] private float _areaBorderY;

        protected override IEnumerator Sequence()
        {
            while(true)
            {
                for (int i = 0; i < _nukeCount; i++)
                {
                    var nuke = Spawn();

                    if (i != 0)
                    {
                        nuke.GetComponent<AudioEvent>()?.Disable();
                    }
                }
                yield return new WaitForSeconds(_nukeInterval);
            }
        }

        protected override GameObject Spawn()
        {
            return Instantiate(_hazard, GetSpawnPosition(), Quaternion.identity);
        }

        protected Vector2 GetSpawnPosition()
        {
            return new Vector2(Random.Range(-_areaBorderX, _areaBorderX), Random.Range(-_areaBorderY, _areaBorderY));

        }
    }
}
