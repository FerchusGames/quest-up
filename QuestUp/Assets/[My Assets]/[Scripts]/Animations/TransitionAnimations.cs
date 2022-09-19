using System;
using System.Collections;
using UnityEngine;

namespace QuestUp
{
    public class TransitionAnimations : MonoBehaviour
    {
        public Animator _animator = null;

        public void TriggerTransition(Action onTransitionComplete)
        {
            StartCoroutine(TriggerTransitionCoroutine(onTransitionComplete));
        }

        private IEnumerator TriggerTransitionCoroutine(Action onTransitionComplete)
        {
            PlayBarsIn();
            yield return new WaitForSeconds(1); 
            onTransitionComplete?.Invoke();
            yield return new WaitForSeconds(0.2f);
            PlayBarsOut();
        }

        private void PlayBarsIn()
        {
            _animator.ResetTrigger("BarsOut");
            _animator.SetTrigger("BarsIn");
        }

        private void PlayBarsOut()
        {
            _animator.ResetTrigger("BarsIn");
            _animator.SetTrigger("BarsOut");
        }
    }
}
