using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


namespace SpecialAdventure
{
    public class EnemyController : IController, IFixedExecute
    {
        //private SimplePatrolAI _patrolModel;

        private EnemyView _enemy;

        private ProtectorAI _protectorAI;
        private ProtectedZone _protectedZone;
        private PlayerView _playerView;

        public EnemyController(Data data, PlayerView player)
        {
            _playerView = player;
            var enemyData = data.GetObjectInfo<EnemyObjectProperty>("Enemy");
            var prototype = enemyData.GetPrefab<EnemyView>();
            
            _enemy = new RegularFactory<EnemyView>(prototype).GetObject();
            
            SetUpEnemy(_enemy, enemyData.Positions[0]);

            //_patrolModel = new SimplePatrolAI(_enemy, new SimplePatrolAIModel(enemyData.AIConfig));
            //_enemy.GetComponent<AIDestinationSetter>().target =_playerView.transform;

            _protectorAI = new ProtectorAI(_enemy, new PatrolAIModel(enemyData.AIConfig.Waypoints), _enemy.GetComponent<AIDestinationSetter>(), _enemy.GetComponent<AIPatrolPath>());
            _protectorAI.Init();

            _protectedZone = new ProtectedZone( new List<IProtector> { _protectorAI });
            _protectedZone.Init();
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
