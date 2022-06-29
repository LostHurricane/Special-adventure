using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


namespace SpecialAdventure
{
    public class EnemyController : IController, IFixedExecute
    {
        private IFactory<EnemyView> _factory;

        private SimplePatrolAI _patrolModel;

        private EnemyView _enemy;

        public EnemyController(Data data)
        {
            var enemyData = data.GetObjectInfo<EnemyObjectProperty>("Enemy");
            var prototype = enemyData.GetPrefab<EnemyView>();
            _factory = new RegularFactory<EnemyView>(prototype);

            

            _enemy = _factory.GetObject();
            SetUpEnemy(_enemy, enemyData.Positions[0]);

            _patrolModel = new SimplePatrolAI(_enemy, new SimplePatrolAIModel(enemyData.AIConfig));

            _enemy.GetComponent<AIDestinationSetter>().target = GameObject.Find("Player(Clone)").transform;
        }

        public void FixedExecute(float deltaTime)
        {
            //_patrolModel.FixedUpdate();
        }

        private void SetUpEnemy (EnemyView enemy, Vector3 placement)
        {
            enemy.transform.position = placement;
        }
    }
}
