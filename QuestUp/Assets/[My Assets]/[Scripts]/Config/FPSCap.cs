using UnityEngine;

public class FPSCap : MonoBehaviour
{
    [SerializeField] private int _applicationTargetFrameRate = default;

    void Start()
    {
        // Make the game run as fast as possible
        Application.targetFrameRate = _applicationTargetFrameRate;
    }
}
