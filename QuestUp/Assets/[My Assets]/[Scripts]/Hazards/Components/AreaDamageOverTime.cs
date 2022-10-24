using System.Collections;
using UnityEngine;

namespace QuestUp
{
    public class AreaDamageOverTime : MonoBehaviour
    {
        [SerializeField] AudioClip _audioClip = null;

        [SerializeField] private int _damageValue = default;
        [SerializeField] private float _damageRate = default;

        private IEnumerator _coroutineDamageOverTime = null;

        private void Start()
        {
            _coroutineDamageOverTime = DamageOverTime();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            StartCoroutine(_coroutineDamageOverTime);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            StopCoroutine(_coroutineDamageOverTime);    
        }

        private IEnumerator DamageOverTime()
        {
            while (true)
            {
                if (_audioClip != null) AudioManager.Instance.PlaySoundEffect(_audioClip);
                HealthManager.Instance.LoseHealth(_damageValue);
                yield return new WaitForSeconds(_damageRate);
            }
        }
    }
}
