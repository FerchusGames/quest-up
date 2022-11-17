using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace QuestUp
{
    public class LaserBeamSequence : HazardSequence
    {
        private IList<GameObject> _lasers = null;

        [SerializeField] private float _laserLifespan = default;
        [SerializeField] private float _laserSpawnRate = default;
        [SerializeField] private float _maxVerticalOffset = default;
        [SerializeField] private float _maxHorizontalOffset = default;

        private Vector2 _laserPosition = default;

        private float _laserRotation = default;

        protected override void InitializeValues()
        {
            _laserSpawnRate /= HazardManager.Instance.RateMultiplier;
        }

        protected override IEnumerator Sequence()
        {
            _lasers = new List<GameObject>();

            while (true)
            {
                _lasers.Add(Spawn());
                yield return new WaitForSeconds(_laserSpawnRate);
            }
        }

        private void SetRotation()
        {
            _laserRotation = Rotation360();
        }

        private void SetPosition()
        {
            float xPos = UnityEngine.Random.Range(-_maxHorizontalOffset, _maxHorizontalOffset);
            float yPos = UnityEngine.Random.Range(-_maxVerticalOffset, _maxVerticalOffset);
            _laserPosition = new Vector2(xPos, yPos);
        }

        protected override GameObject Spawn()
        {
            SetRotation();
            SetPosition();

            GameObject laser = Instantiate(_hazard, _laserPosition, Quaternion.Euler(0, 0, _laserRotation));
            Destroy(laser, _laserLifespan);

            return laser;
        }

        public override void Despawn()
        {
            foreach (GameObject laser in _lasers)
            {
                Destroy(laser);
            }
            Destroy(gameObject);
        }

        private float Rotation360()
        {
            return UnityEngine.Random.Range(0, 360);
        }

        private float HorizontalVerticalRotation()
        {
            if (UnityEngine.Random.value < 0.5f)
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
