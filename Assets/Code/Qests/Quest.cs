using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class Quest : IQuest, IDisposable
    {
        private readonly QuestObjectView _questObjectView;
        private readonly IQuestModel _model;

        private bool _active;
        public bool IsCompleted { get; private set; }

        public event Action<IQuest> Completed;

        public Quest(QuestObjectView questObjectView, IQuestModel model)
        {
            _questObjectView = questObjectView;
            _model = model;
        }

        public void Reset()
        {
            if (_active)
            {
                return;
            }

            _active = true;
            IsCompleted = false;
            _questObjectView.OnLevelObjectContact += OnContact;
            _questObjectView.ProcessActivate();
        }

        private void Complete()
        {
            if (!_active)
            {
                return;
            }

            _active = false;
            IsCompleted = true;
            _questObjectView.OnLevelObjectContact -= OnContact;
            _questObjectView.ProcessComplete();
            OnCompleted();
        }

        private void OnCompleted()
        {
            Completed?.Invoke(this);
        }

        private void OnContact(PlayerView view)
        {
            if (_model.TryComplete(view.gameObject))
            {
                Complete();
            }
        }

        public void Dispose()
        {
            if (_active)
            {
                _questObjectView.OnLevelObjectContact -= OnContact;
            }
        }
    }
}
