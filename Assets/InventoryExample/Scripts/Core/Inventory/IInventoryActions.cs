using System.Collections.Generic;

public interface IInventoryActions
{
    bool Add(int cellID, BaseItem item);
    bool Remove(int cellID);
    bool IsCellHasItem(int cellID);
    BaseItem GetItem(int cellID);
    IEnumerable<BaseItem> GetItems();
    int GetSize();
}
