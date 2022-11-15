using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

namespace QuestUp
{
    public class HazardManager : MonoBehaviour
    {
        public static HazardManager Instance { get; private set; }

        [SerializeField] private HazardSequence[] _hazardSequencerPrefabs;
        [SerializeField] private LevelSO[] _levelScriptableObjects;

        private int _currentLevel = default;
        private int _hazardAmount = default;

        public float SpeedMultiplier { get; private set; }
        public float CountMultiplier { get; private set; }
        public float RateMultiplier { get; private set; }

        public LevelSO CurrentLevelSO { get; private set; }

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

        public void SpawnSequences()
        {
            SetCurrentLevelValues();

            var hazards = ChooseSequences();
            
            foreach (var hazard in hazards)
            {
                Instantiate(hazard);
            }
        }

        private IReadOnlyList<HazardSequence> ChooseSequences()
        {
            return new List<HazardSequence>(_hazardSequencerPrefabs).Shuffle().Take(CurrentLevelSO.HazardAmount).ToList();
        }
    }
}
