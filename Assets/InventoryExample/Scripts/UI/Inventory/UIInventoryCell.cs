using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryCell : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, 
    IPointerEnterHandler, IPointerExitHandler, IDroppable<Tuple<UIInventoryCell, BaseItem>>
{
    [SerializeField] private Image _icon;
    private BaseItem _item;
    private int _cellID;
    
    public void Init(int cellID)
    {
        _cellID = cellID;
        SetItem(null);
    }
    
    public void SetItem(BaseItem item)
    {
        _item = item;
        if (item != null)
        {
            _icon.enabled = true;
            _icon.sprite = Storages.ItemsVisualDataStorage.GetData(_item.ID).Icon;
        }
        else
        {
            _icon.enabled = false;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        User.Current.Inventory.Remove(_cellID);
        SetItem(null);
    }
    
    public void OnDrop(Tuple<UIInventoryCell, BaseItem> data)
    {
        if (!User.Current.Inventory.IsCellHasItem(_cellID))
        {
            if (this != data.Item1)
            {
                User.Current.Inventory.Remove(data.Item1._cellID);
                data.Item1.SetItem(null);
            }

            User.Current.Inventory.Add(_cellID, data.Item2);
            SetItem(data.Item2);
        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(_item == null) return;
        UIInventoryDragContainer.Context.StartDrag(new Tuple<UIInventoryCell, BaseItem>(this, _item));
    }
    public void OnDrag(PointerEventData eventData)
    {
        UIInventoryDragContainer.Context.ProcessDrag();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        UIInventoryDragContainer.Context.EndDrag();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIInventoryDragContainer.Context.EnterContainer(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIInventoryDragContainer.Context.ExitContainer(this);
    }
}
