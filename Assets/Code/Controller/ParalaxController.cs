using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpecialAdventure
{
    public class ParalaxController : IExecute
    {
        private float _scrollingSpeed;

        private Camera _camera;
        private Transform _transform;
        private List<SpriteRenderer> _backgroundPart;

        private SpriteRenderer _firstChild;
        private SpriteRenderer _lastChild;

        private Vector3 _lastCamPosition;

        public ParalaxController(Data data, Camera camera, float scrollingSpeed = 0.2f)
        {
            _camera = camera;
            var prefab = data.GetObjectInfo("Background").GetPrefab();
            _scrollingSpeed = scrollingSpeed;
            _transform = Object.Instantiate(prefab, _camera.transform.position, Quaternion.identity).transform;
            _backgroundPart = new List<SpriteRenderer>();

            for (int i = 0; i < _transform.childCount; i++)
            {
                var child = _transform.GetChild(i);

                if (child.TryGetComponent<SpriteRenderer>(out var renderer))
                {
                    _backgroundPart.Add(renderer);
                }
            }
            SortChildren();
        }

        public void Execute(float deltaTime)
        {
            Vector3 movement = (_camera.transform.position - _lastCamPosition) * _scrollingSpeed;

            _transform.position = new Vector3(_transform.position.x, _camera.transform.position.y, _transform.position.z);
            _transform.Translate(movement);

            var relationToFirst = _camera.transform.position.x - _firstChild.transform.position.x;
            var relationToLast = _camera.transform.position.x - _lastChild.transform.position.x;

            if ((relationToLast * relationToFirst) > 0)
            {
                SortChildren();
                Debug.Log(_lastChild.IsVisibleFrom(_camera));
                if (!_lastChild.IsVisibleFrom(_camera))
                {
                    Vector3 lastPosition = _firstChild.transform.position;
                    Vector3 firstSize = (_firstChild.bounds.max - _firstChild.bounds.min);
                    Vector3 lastSize = (_lastChild.bounds.max - _lastChild.bounds.min);

                    var nextX = lastPosition.x + ((lastSize.x + firstSize.x) * 0.5f * (relationToFirst > 0f ? 1 : -1));
                    _lastChild.transform.position = new Vector3(nextX, _lastChild.transform.position.y, _lastChild.transform.position.z);

                }
            }
            _lastCamPosition = _camera.transform.position;
        }


        private void SortChildren()
        {
            _backgroundPart = _backgroundPart.SortByDistance(_camera.transform.position);
            _firstChild = _backgroundPart.FirstOrDefault();
            _lastChild = _backgroundPart.LastOrDefault();
        }


    }
}
