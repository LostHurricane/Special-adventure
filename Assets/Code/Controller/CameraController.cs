using UnityEngine;

namespace SpecialAdventure
{
    public class CameraController : IExecute
    {
        private Camera _camera;
        private Transform _target;
        private Vector3 _offsetPosition;

        public CameraController(Transform target, Vector3 offsetPosition, out Camera camera)
        {
            _target = target;
            _offsetPosition = offsetPosition;
            _camera = new GameObject("Camera").AddComponent<Camera>(); 
            Camera.SetupCurrent(_camera);
            _camera.orthographic = true;
            camera = _camera;
        }

        public void Execute(float deltaTime)
        {
            _camera.transform.position = _target.position + _offsetPosition;
        }

    }
}
