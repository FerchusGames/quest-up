using UnityEngine;

namespace QuestUp
{
    public class AudioEvent : MonoBehaviour
    {
        [SerializeField] AudioClip _audioClip;

        [SerializeField] private float _volumeScale = 1f;

        private bool disabled = false;

        private void PlaySoundEffect()
        {
            if (disabled) return;

            AudioManager.Instance.PlaySoundEffect(_audioClip, _volumeScale);
        }

        public void Disable()
        {
            disabled = true;
        }
    }
}
