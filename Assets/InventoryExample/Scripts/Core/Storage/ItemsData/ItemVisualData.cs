using System;
using UnityEngine;
[Serializable]
public class ItemVisualData
{
    [SerializeField] private long _id;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _visualName;
    public long ID => _id;
    public Sprite Icon => _icon;
    public string VisualName => _visualName;
}
