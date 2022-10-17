using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class AreaDamageOverTime : MonoBehaviour
    {
        [SerializeField] private int _damageValue = default;
        [SerializeField] private float _damageRate = default;

        private IEnumerator _coroutine = null;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Entered Damage Area");
            _coroutine = DamageOverTime();
            StartCoroutine(_coroutine);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Debug.Log("Exited Damage Area");
            StopCoroutine(_coroutine);    
        }

        private IEnumerator DamageOverTime()
        {
            while (true)
            {
                HealthManager.Instance.LoseHealth(_damageValue);
                yield return new WaitForSeconds(_damageRate);
            }
        }
    }
}
