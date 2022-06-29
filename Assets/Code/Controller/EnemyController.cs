using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class EnemyController : IFixedExecute
    {
        private IFactory<EnemyView> _factory;

        private SimplePatrolAI _patrolModel;

        private EnemyView _enemy;

        public EnemyController(Data data, AIConfig aIConfig)
        {
            var enemyData = data.GetObjectInfo<EnemyObjectProperty>("Enemy");
            var prototype = enemyData.GetPrefab<EnemyView>();
            _factory = new RegularFactory<EnemyView>(prototype);

            

            _enemy = _factory.GetObject();
            SetUpEnemy(_enemy, new Vector3( 4 , 3 , 0));

            _patrolModel = new SimplePatrolAI(_enemy, new SimplePatrolAIModel(aIConfig));
        }

        public void FixedExecute(float deltaTime)
        {
            _patrolModel.FixedUpdate();
        }

        private void SetUpEnemy (EnemyView enemy, Vector3 placement)
        {
            enemy.transform.position = placement;
        }
    }
}
