using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace SpecialAdventure
{
    public class PoolSystem <T> where T : MonoBehaviour
    {
        private HashSet<T> _pool;
        private Transform _rootPool;
        private readonly int _capasityIncrement;
        private IFactory<T> _factory;

        public PoolSystem (IFactory<T> factory, int capasityIncrement, string poolName)
        {
            _capasityIncrement = capasityIncrement;
            _pool = new HashSet<T>();
            _factory = factory;

            GameObject.Find(poolName)?.TryGetComponent(out _rootPool);
            if (!_rootPool)
                _rootPool = new GameObject(poolName).transform;
        }

        public T GetFromPool(Vector3 position)
        {
            var temp = GetItem();
            temp.transform.position = position;
            return temp;
        }

        public bool AddToPool(T item)
        {
            if(_pool.Contains(item))
            {
                return false;
            }
            else
            {
                _pool.Add(item);
                return true;
            }
        }

        private T GetItem ()
        {
            var item = _pool.FirstOrDefault(a => !a.gameObject.activeSelf && a.TryGetComponent<T>(out _));
            if (item == null)
            {
                for (var i = 0; i < _capasityIncrement; i++)
                {
                    var instantiate = _factory.GetObject();
                    ReturnToPool(instantiate.transform);
                    _pool.Add(instantiate);
                }
                item = GetItem();
            }
            return item;
        }


        public void ReturnToPool(Transform transform)
        {
            transform.SetParent(_rootPool);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
        }

    }
}
