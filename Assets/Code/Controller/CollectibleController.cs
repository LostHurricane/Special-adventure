using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class CollectibleController : IExecute, ICleanup
    {
        private PoolSystem<InteractiveObjectView> _collectiblePool;
        private HashSet<InteractiveObjectView> _activeCollectible;
        private Transform _parentCollectibles;
        private List<Vector3> _placemats;

        private SpriteAnimator _spriteAnimator;



        public CollectibleController(Data data)
        {
            var collectible = data.GetObjectInfo<MultipleInteractiveObjectProperty>("Apple");

            _spriteAnimator = new SpriteAnimator(collectible.GetAnimatorConfig());
            _collectiblePool = new PoolSystem<InteractiveObjectView>(new RegularFactory<InteractiveObjectView>(collectible.GetPrefab<InteractiveObjectView>()), 8, "CollectiblesPool");
            _activeCollectible = new HashSet<InteractiveObjectView>();
            _parentCollectibles = new GameObject("Apples").transform;
            _placemats = new List<Vector3>(collectible.Positions);

            FullPlacement(_placemats);
        }

        public void Execute (float deltaTime)
        {
            _spriteAnimator.Execute(deltaTime);
            
        }

        private void FullPlacement(IEnumerable<Vector3> coordinates)
        {
            foreach (var vector in coordinates)
            {
                var collectible = _collectiblePool.GetFromPool(vector);
                SetUpNew(collectible);
            }
        }

        private void SetUpNew(InteractiveObjectView collectible)
        {
            _activeCollectible.Add(collectible);
            collectible.gameObject.SetActive(true);
            collectible.OnLevelObjectTriggerEnter += PickUp;
            collectible.transform.SetParent(_parentCollectibles);
            _spriteAnimator.StartAnimation(collectible.SpriteRenderer, AnimStatePlayer.Idle, true, 10);


        }

        private void Release(InteractiveObjectView collectible)
        {
            _activeCollectible.Remove(collectible);
            collectible.OnLevelObjectTriggerEnter -= PickUp;
            _collectiblePool.ReturnToPool(collectible.transform);
            _spriteAnimator.StopAnimation(collectible.SpriteRenderer);
        }

       

        private void PickUp(IActivator contactView, InteractiveObjectView collectible)
        {
            contactView.Interract(InteractiveObjectType.Apple);
            _collectiblePool.ReturnToPool(collectible.transform);

        }
         

        public void Cleanup()
        {
            if (_activeCollectible.Count != 0)
            {
                foreach (var item in _activeCollectible)
                {
                    Release(item);
                }
            }
        }



    }

    
}
