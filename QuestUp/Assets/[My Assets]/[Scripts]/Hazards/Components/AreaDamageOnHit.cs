using UnityEngine;

namespace QuestUp
{
    public class AreaDamageOnHit : MonoBehaviour
    {
        [SerializeField] private AudioClip _audioClip = null;
        [SerializeField] private float _volumeScale = 1f;

        [SerializeField] private int _damageValue = default;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_audioClip != null) AudioManager.Instance.PlaySoundEffect(_audioClip, _volumeScale);
            HealthManager.Instance.LoseHealth(_damageValue);
        }
    }
}
