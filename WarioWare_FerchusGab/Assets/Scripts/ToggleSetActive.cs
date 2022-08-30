using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : MonoBehaviour
{
    [SerializeField] GameObject _objectToToggle;

    public void _ToggleSetActive()
    {
        _objectToToggle.SetActive(!_objectToToggle.activeSelf);
    }
}
