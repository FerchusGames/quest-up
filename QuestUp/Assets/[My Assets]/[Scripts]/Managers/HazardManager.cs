using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class HazardManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] _hazardSequencerPrefabs;

        private int currentLevel = default;

        private void Start()
        {
            currentLevel = GameManager.Instance.LevelCount;
        }

        private void SpawnHazardSequences()
        {

        }
    }
}
