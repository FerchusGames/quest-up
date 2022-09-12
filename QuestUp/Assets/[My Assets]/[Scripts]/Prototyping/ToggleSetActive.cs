using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestUp
{
    public class ToggleSetActive : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToToggle = null;

        public void _ToggleSetActive()
        {
            _objectToToggle.SetActive(!_objectToToggle.activeSelf);
        }
    }
}
