using System;
using UnityEngine;

public class UIInventoryDragContainer : MonoBehaviour
{
     private static DragContext<Tuple<UIInventoryCell, BaseItem>> _context;
     public static DragContext<Tuple<UIInventoryCell, BaseItem>> Context => _context;

     [SerializeField] private RectTransform _dragContainer;

     private GameObject _visualDraggableObject;
     private Camera _camera;
     private void Awake()
     {
         _camera = Camera.main;
         
         _context = new DragContext<Tuple<UIInventoryCell, BaseItem>>();
         _context.OnStartDrag += ContextStartDrag;
         _context.OnEndDrag += ContextOnEndDrag;
         _context.OnDrag += ContextOnDrag;
     }

     private void ContextOnDrag(Tuple<UIInventoryCell, BaseItem> data)
     {
         if (_visualDraggableObject != null)
         {
             _visualDraggableObject.transform.position = Input.mousePosition;
         }
     }

     private void ContextStartDrag(Tuple<UIInventoryCell, BaseItem> data)
     {
         _visualDraggableObject = Instantiate(data.Item1.gameObject, _dragContainer);
     }

     private void ContextOnEndDrag(Tuple<UIInventoryCell, BaseItem> data)
     {
         Destroy(_visualDraggableObject);
     }
}
