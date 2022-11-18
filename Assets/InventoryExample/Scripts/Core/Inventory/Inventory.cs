using System;
using System.Collections.Generic;
using Newtonsoft.Json;
[Serializable]
public class Inventory : IInventoryActions
{
    [JsonProperty] private BaseItem[] _items;

    public event Action OnChange;
    public bool Add(int cellID, BaseItem item)
    {
        _items[cellID] = item;
        OnChange?.Invoke();
        return true;
    }

    public bool Remove(int cellID)
    {
        _items[cellID] = null;
        OnChange?.Invoke();
        return true;
    }

    public BaseItem GetItem(int cellID)
    {
        return _items[cellID];
    }

    public IEnumerable<BaseItem> GetItems()
    {
        return _items;
    }

    public int GetSize()
    {
        return _items.Length;
    }

    public bool IsCellHasItem(int cellID)
    {
        return _items[cellID] != null;
    }
    
    public Inventory(int size)
    {
        _items = new BaseItem[size];
    }
}