using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class ProtectedZone
    {
        private readonly List<IProtector> _protectors;
        private readonly LevelObjectTrigger _view;

        public ProtectedZone(List<IProtector> protectors)
        {
            _view = GameObject.Find("TriggerObject").GetComponent<LevelObjectTrigger>();
            _protectors = protectors;
            Debug.Log($"_protectors {_protectors.Count}");

        }

        public void Init()
        {
            _view.TriggerEnter += OnContact;
            _view.TriggerExit += OnExit;
        }

        public void Deinit()
        {
            _view.TriggerEnter -= OnContact;
            _view.TriggerExit -= OnExit;
        }

        private void OnContact(GameObject gameObject)
        {
            foreach (var protector in _protectors)
            {
                Debug.Log($"protector activated");
                protector.StartProtection(gameObject);

            }


        }

        private void OnExit(GameObject gameObject)
        {
            foreach (var protector in _protectors)
                protector.FinishProtection(gameObject);
        }
    }
}