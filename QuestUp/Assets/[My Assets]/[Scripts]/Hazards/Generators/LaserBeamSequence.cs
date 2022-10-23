using System.Collections;
using UnityEngine;

namespace QuestUp
{
    public class LaserBeamSequence : HazardSequence
    {
        [SerializeField] private float _laserLifespan = default;
        [SerializeField] private float _laserSpawnRate = default;
        [SerializeField] private float _maxVerticalOffset = default;
        [SerializeField] private float _maxHorizontalOffset = default;

        private Vector2 _laserPosition = default;

        private float _laserRotation = default;

        private void Start()
        {
            StartCoroutine(Sequence());
        }

        public override IEnumerator Sequence()
        {
            while (true)
            {
                CreateLaser();

                yield return new WaitForSeconds(_laserSpawnRate);
            }
        }

        private void SetRotation()
        {
            _laserRotation = Rotation360();
        }

        private void SetPosition()
        {
            float xPos = Random.Range(-_maxHorizontalOffset, _maxHorizontalOffset);
            float yPos = Random.Range(-_maxVerticalOffset, _maxVerticalOffset);
            _laserPosition = new Vector2(xPos, yPos);
        }

        private void CreateLaser()
        {
            SetRotation();
            SetPosition();

            GameObject laser = Instantiate(_hazardPrefab, _laserPosition, Quaternion.Euler(0, 0, _laserRotation));
            Destroy(laser, _laserLifespan);
        }

        private float Rotation360()
        {
            return Random.Range(0, 360);
        }

        private float HorizontalVerticalRotation()
        {
            if (Random.value < 0.5f)
            {
                return 0;
            }

            else
            {
                return 90;
            }
        }
    }

    
}
