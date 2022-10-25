using UnityEngine;

namespace QuestUp
{
    public class DestroyEvent : MonoBehaviour
    {
        public void DestroySelf()
        {
            Destroy(gameObject);
        }

    }
}
