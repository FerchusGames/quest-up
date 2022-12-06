using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class RestartMusicEvent : MonoBehaviour
    {
        private void Start()
        {
            AudioManager.Instance.RestartMusic();
        }
    }
}
