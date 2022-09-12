using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class TransitionAnimations : MonoBehaviour
    {
        public Animator _animator = null;

        public void PlayBarsIn()
        {
            _animator.ResetTrigger("BarsOut");
            _animator.SetTrigger("BarsIn");
        }

        public void PlayBarsOut()
        {
            _animator.ResetTrigger("BarsIn");
            _animator.SetTrigger("BarsOut");
        }
    }
}
