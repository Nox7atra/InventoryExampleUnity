using System.Collections.Generic;
using UnityEngine;

public class ItemsVisualDataStorage : IStorageActions<ItemVisualData>
{
    private const string DataPath = "ItemsVisualDataCollection";
    private Dictionary<long, ItemVisualData> _data;

    public void Load()
    {
        var data = Resources.Load<ItemVisualDataSOCollection>(DataPath).data;
        _data = new Dictionary<long, ItemVisualData>();
        foreach (var itemVisualData in data)
        {
            if (!_data.ContainsKey(itemVisualData.ID))
            {
                _data.Add(itemVisualData.ID, itemVisualData);
            }
        }
    }
    public ItemVisualData GetData(long id)
    {
        return _data[id];
    }

    public ItemsVisualDataStorage()
    {
        Load();
    }
}
