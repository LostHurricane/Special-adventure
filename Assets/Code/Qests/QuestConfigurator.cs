using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpecialAdventure
{
    public class QuestConfigurator : MonoBehaviour
    {


        [SerializeField]
        private QuestObjectView _singleQuestView;
        [SerializeField]
        private QuestStoryConfig[] _questStoryConfigs;
        [SerializeField]
        private QuestObjectView[] _questObjects;


        private Quest _singleQuest;
        private List<IQuestStory> _questStories;

        private readonly Dictionary<QuestType, Func<IQuestModel>> _questFactories = new Dictionary<QuestType, Func<IQuestModel>>
        {
            { QuestType.Switch, () => new QuestSwitchModel() },
        };

        private readonly Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>> _questStoryFactories = new Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>
        {
            { QuestStoryType.Common, questCollection => new QuestStory(questCollection) },
        };


        private void Start()
        {
            _singleQuest = new Quest(_singleQuestView, new QuestSwitchModel());
            _singleQuest.Reset();

            _questStories = new List<IQuestStory>();

            foreach (var questStoryConfig in _questStoryConfigs)
            {
                _questStories.Add(CreateQuestStory(questStoryConfig));
            }
            


        }

        private IQuestStory CreateQuestStory (QuestStoryConfig config)
        {
            var quests = new List<IQuest>();

            foreach (var questConfig in config.Quests)
            {
                var quest = CreateQuest(questConfig);
                
                if (quest == null)
                {
                    continue;
                }
                
                quests.Add(quest);
                Debug.Log($"quests.Count {quests.Count}");

            }

            return _questStoryFactories[config.QuestStoryType].Invoke(quests);
        }

        private IQuest CreateQuest(QuestConfig questConfig)
        {
            var questId = questConfig.Id;
            var questView = _questObjects.FirstOrDefault(par => par.ID == questId);

            if (questView == null)
            {
                return null;
            }

            if (_questFactories.TryGetValue(questConfig.QuestType, out var factory))
            {
                return new Quest(questView, factory.Invoke());
            }

            return null;

        }

        private void OnDestroy()
        {
            _singleQuest.Dispose();
            _questStories.Clear();
        }


    }
}
