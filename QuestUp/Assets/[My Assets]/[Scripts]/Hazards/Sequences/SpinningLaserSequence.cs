using System.Collections;
using UnityEngine;

namespace QuestUp
{
    public class SpinningLaserSequence : HazardSequence
    {
        GameObject[] _lasers = null; 

        [SerializeField] int _laserCount = default(int);
        [SerializeField] float _rotationSpeed = default;
        [SerializeField] float _maxDirectionDuration = default;

        protected override IEnumerator Sequence()
        {
            Spawn();
            StartCoroutine(ChangeDirection());
            while (true)
            {
                Spin();
                yield return null;
            }
        }

        private IEnumerator ChangeDirection()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(0, _maxDirectionDuration));
                _rotationSpeed = -_rotationSpeed;
            }
        }

        protected override GameObject Spawn()
        {
            _lasers = new GameObject[_laserCount];

            for (int i = 0; i < _laserCount; i++)
            {
                _lasers[i] = Instantiate(_hazard, transform.position, GetLaserRotation(i), transform);
            }
            return null;
        }
        
        private Quaternion GetLaserRotation(int i)
        {
            float zRotation = 360 / _laserCount * i;

            Vector3 rotationVector = Vector3.forward * zRotation;
            return Quaternion.Euler(rotationVector);
        }

        private void Spin()
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            currentRotation.z += _rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(currentRotation);
        }
    }
}
