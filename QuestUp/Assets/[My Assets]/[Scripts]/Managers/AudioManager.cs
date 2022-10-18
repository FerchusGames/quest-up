using UnityEngine;

namespace QuestUp
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [SerializeField] private AudioSource _audioSourceMusic;
        [SerializeField] private AudioSource _audioSourceSoundEffects;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void PlayMusic(AudioClip audioClip)
        {
            _audioSourceMusic.clip = audioClip;
            _audioSourceMusic.Play();
        }

        public void PlaySoundEffect(AudioClip audioClip)
        {
            _audioSourceSoundEffects.PlayOneShot(audioClip);
        }
    }
}
