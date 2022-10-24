using UnityEngine;

namespace QuestUp
{
    public class AreaDamageOnHit : MonoBehaviour
    {
        [SerializeField] private AudioClip _audioClip;

        [SerializeField] private int _damageValue;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_audioClip != null) AudioManager.Instance.PlaySoundEffect(_audioClip);
            HealthManager.Instance.LoseHealth(_damageValue);
        }
    }
}
