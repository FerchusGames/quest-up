using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace QuestUp
{
    public class LaserBeamGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _laserBeamPrefab = null;

        [SerializeField] private float _laserLifespan;
        [SerializeField] private float _laserSpawnRate;
        [SerializeField] private float _maxVerticalOffset;
        [SerializeField] private float _maxHorizontalOffset;

        private Vector2 _laserPosition;

        private float _laserRotation;

        private void Start()
        {
            StartCoroutine(LaserSequence());
        }

        IEnumerator LaserSequence()
        {
            while(true)
            {
                CreateLaser();

                yield return new WaitForSeconds(_laserSpawnRate);
            }
        }

        private void SetRotation()
        {
            _laserRotation = Random.Range(0, 360);
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

            GameObject laser = Instantiate(_laserBeamPrefab, _laserPosition, Quaternion.Euler(0, 0, _laserRotation));
            Destroy(laser, _laserLifespan);
        }
    }
}
