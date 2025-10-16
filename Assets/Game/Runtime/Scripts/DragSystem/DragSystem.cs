using System;
using Game.Runtime.Scripts.Camera;
using Game.Runtime.Scripts.EventBusThings;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game.Runtime.Scripts.DragSystem
{
    public class DragSystem : ITickable, IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly CameraRayCaster _cameraRayCaster;

        private IDraggable _lastDraggable;

        [Inject]
        public DragSystem(SignalBus signalBus, CameraRayCaster cameraRayCaster)
        {
            _signalBus = signalBus;
            _cameraRayCaster = cameraRayCaster;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<RaycastColliderHitSignal>(HandleCollision);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<RaycastColliderHitSignal>(HandleCollision);
        }

        private void HandleCollision(RaycastColliderHitSignal raycastColliderHitSignal)
        {
            if (!raycastColliderHitSignal.HitObject.TryGetComponent(out IDraggable draggable))
                return;

            if (_lastDraggable != null && Mouse.current.leftButton.isPressed)
                return;

            if (_lastDraggable != draggable)
            {
                _lastDraggable?.ReturnTo();
                _lastDraggable = draggable;

                _lastDraggable.OnBeginDrag();
            }
        }

        public void Tick()
        {
            Dragging();
            if (!Mouse.current.leftButton.isPressed)
            {
                _lastDraggable?.ReturnTo();
                _lastDraggable = null;
            }
        }

        private void Dragging()
        {
            if (_lastDraggable == null)
                return;

            Vector2 screenPos = Mouse.current.position.ReadValue();
            Vector3 worldPos = _cameraRayCaster.Camera.ScreenToWorldPoint(screenPos);
            worldPos.z = 0f;

            _lastDraggable.OnDrag(worldPos);
        }
    }
}