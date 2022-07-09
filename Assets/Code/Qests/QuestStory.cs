using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpecialAdventure
{
    public class QuestStory : IQuestStory, IDisposable
    {
        public bool IsDone => _questCollection.All(value => value.IsCompleted);

        private readonly List<IQuest> _questCollection;

        public QuestStory(List<IQuest> questCollection)
        {
            _questCollection = questCollection;

            Subscribe();
            ResetQuest(0);
        }

        private void Subscribe()
        {
            foreach (var quest in _questCollection)
            {
                //Debug.Log($"quest id = }")
                quest.Completed += OnQuestCompleted;
            }
        }

        private void UnSubscribe()
        {
            foreach (var quest in _questCollection)
            {
                quest.Completed -= OnQuestCompleted;
            }
        }

        private void OnQuestCompleted(IQuest obj)
        {
            var index = _questCollection.IndexOf(obj);
            if (IsDone)
            {
                Debug.Log("Quest Story is done ");
            }
            else
            {
                ResetQuest(++index);
            }
        }

        private void ResetQuest(int index)
        {
            if (index < 0 || index >= _questCollection.Count)
            {
                return;
            }

            var nextQuest = _questCollection[index];
            if (nextQuest.IsCompleted)
            {
                OnQuestCompleted(nextQuest);
            }

            else
            {
                _questCollection[index].Reset();
            }
        }

        public void Dispose()
        {
            UnSubscribe();  
        }
    }
}
