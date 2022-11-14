using System.Collections;
using System.Collections.Generic;
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
        private float _speedMultiplier = default;
        private float _countMultiplier = default;
        private float _rateMultiplier = default;

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

        private void SetCurrentLevelValues()
        {
            CurrentLevelSO = GetCurrentLevelSO();

            _hazardAmount = CurrentLevelSO.HazardAmount;
            _speedMultiplier = GetCurrentLevelValue(CurrentLevelSO.SpeedMinMultiplier, CurrentLevelSO.SpeedMaxMultiplier);
            _countMultiplier = GetCurrentLevelValue(CurrentLevelSO.CountMinMultiplier, CurrentLevelSO.CountMaxMultiplier);
            _rateMultiplier = GetCurrentLevelValue(CurrentLevelSO.RateMinMultiplier, CurrentLevelSO.RateMaxMultiplier);
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

        private void SpawnSequences()
        {

        }
    }
}
