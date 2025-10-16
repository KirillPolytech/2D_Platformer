using UnityEngine;

namespace Game.Runtime.Scripts.DragSystem
{
    public interface IDraggable
    {
        void OnBeginDrag();
        void OnDrag(Vector3 pointerWorldPos);
        void OnEndDrag(Vector3 pointerWorldPos);
        void ReturnTo();
    }
}