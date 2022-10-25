using UnityEngine;

namespace QuestUp
{
    public class AudioEvent : MonoBehaviour
    {
        [SerializeField] AudioClip _audioClip;

        private bool disabled = false;

        private void PlaySoundEffect()
        {
            if (disabled) return;

            AudioManager.Instance.PlaySoundEffect(_audioClip);
        }

        public void Disable()
        {
            disabled = true;
        }
    }
}
