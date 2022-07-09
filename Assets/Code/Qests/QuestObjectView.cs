using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    [RequireComponent(typeof(Collider2D))]
    public class QuestObjectView : MonoBehaviour, ISpriteRenderer, IView, ITrigger
    {
        [SerializeField]
        private int _id;
        public int ID => _id;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;


        [SerializeField]
        private Color _defaultColor;

        [SerializeField]
        private Color _completedColor;

        public Action<IActivator, ITrigger> OnLevelObjectTriggerEnter { get; set ; }
        public Action<PlayerView> OnLevelObjectContact { get; set; }

        private void OnEnable()
        {
            _spriteRenderer.color = _defaultColor;
        }

        public void ProcessComplete()
        {
            SpriteRenderer.color = _completedColor;
        }
        public void ProcessActivate()
        {
            SpriteRenderer.color = _defaultColor;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent <IActivator> (out var view))
            {
                //tesing two options of events
                OnLevelObjectTriggerEnter?.Invoke(view, this);
                if (collision.TryGetComponent<PlayerView>(out var pview))
                {
                    OnLevelObjectContact?.Invoke(pview);
                }
            }
        }


    }
}
