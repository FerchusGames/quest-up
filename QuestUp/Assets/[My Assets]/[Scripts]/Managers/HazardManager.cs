using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
    
namespace QuestUp
{
    public class HazardManager : MonoBehaviour
    {
        public static HazardManager Instance { get; private set; }

        [SerializeField] private HazardSequence[] _hazardSequencerPrefabs = null;
        [SerializeField] private LevelSO[] _levelScriptableObjects = null;

        private int _currentLevel = default;
        private int _hazardAmount = default;

        public float SpeedMultiplier { get; private set; }
        public float CountMultiplier { get; private set; }
        public float RateMultiplier { get; private set; }

        public LevelSO CurrentLevelSO { get; private set; }

        private IList<HazardSequence> _hazardSequences = null;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void SetCurrentLevelValues()
        {
            CurrentLevelSO = GetCurrentLevelSO();

            _hazardAmount = CurrentLevelSO.HazardAmount;
            SpeedMultiplier = GetCurrentLevelValue(CurrentLevelSO.SpeedMinMultiplier, CurrentLevelSO.SpeedMaxMultiplier);
            CountMultiplier = GetCurrentLevelValue(CurrentLevelSO.CountMinMultiplier, CurrentLevelSO.CountMaxMultiplier);
            RateMultiplier = GetCurrentLevelValue(CurrentLevelSO.RateMinMultiplier, CurrentLevelSO.RateMaxMultiplier);
        }

        private float GetCurrentLevelValue(float minFloat,  float maxFloat)
        {
            float levelPercentage = Mathf.InverseLerp(CurrentLevelSO.InitialLevel, CurrentLevelSO.LastLevel, _currentLevel);
            return Mathf.Lerp(minFloat, maxFloat, levelPercentage);
        }

        private LevelSO GetCurrentLevelSO()
        {
            _currentLevel = GameManager.Instance.LevelCount;
            foreach (LevelSO levelSO in _levelScriptableObjects)
            {
                if (levelSO.InitialLevel <= _currentLevel && _currentLevel <= levelSO.LastLevel)
                {
                    return levelSO;
                }
            }
            Debug.LogError("No LevelSO for current level");
            return null;
        }

        public void DespawnSequences()
        {
            foreach (HazardSequence hazardSequence in _hazardSequences)
            {
                hazardSequence.Despawn();
            }
        }

        public void SpawnSequences()
        {
            SetCurrentLevelValues();

            var hazardsToSpawn = ChooseSequences();

            _hazardSequences = new HazardSequence[CurrentLevelSO.HazardAmount];

            int i = 0;

            foreach (HazardSequence hazardSequence in hazardsToSpawn)
            {
                _hazardSequences[i] = Instantiate(hazardSequence).GetComponent<HazardSequence>();
                i++;
            }
        }

        private IList<HazardSequence> ChooseSequences()
        {
            return new List<HazardSequence>(_hazardSequencerPrefabs).Shuffle().Take(CurrentLevelSO.HazardAmount).ToList();
        }
    }
}
