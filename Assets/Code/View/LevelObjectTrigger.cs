using System;
using UnityEngine;

namespace SpecialAdventure
{
    public class LevelObjectTrigger : MonoBehaviour
    {
        public Action<GameObject> TriggerEnter;
        public Action<GameObject> TriggerExit;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent<PlayerView>(out _))
            {
                TriggerEnter?.Invoke(other.gameObject);
                Debug.Log("Trigger Activated");
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            TriggerExit?.Invoke(other.gameObject);
        }
    }
}