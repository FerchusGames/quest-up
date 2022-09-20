using QuestUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypingHealthController : MonoBehaviour
{
    public void PrototypingLoseHealth(int damageValue)
    {
        HealthManager.Instance.LoseHealth(damageValue);
    }
}
