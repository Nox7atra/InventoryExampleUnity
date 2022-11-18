using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemVisualDataSOCollection : ScriptableObject
{
    [SerializeField] private List<ItemVisualData> _data;

    public List<ItemVisualData> data => _data;
}
