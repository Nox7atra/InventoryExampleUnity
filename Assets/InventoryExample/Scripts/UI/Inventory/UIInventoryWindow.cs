using System.Collections.Generic;
using UnityEngine;

public class UIInventoryWindow : MonoBehaviour
{
    [SerializeField] private UIInventoryCell _cellTemplate;
    [SerializeField] private RectTransform _cellsRoot;
    
    private List<UIInventoryCell> _cells;
    private IInventoryActions _inventory;
    
    private void Awake()
    {
        _inventory = User.Current.Inventory;
        _cells = new List<UIInventoryCell>();
        for (int i = 0; i < _inventory.GetSize(); i++)
        {
            var cell = Instantiate(_cellTemplate, _cellsRoot);
            cell.Init(i);
            _cells.Add(cell);
        }
    }
    
    private void OnEnable()
    {
        int i = 0;
        foreach (var baseItem in _inventory.GetItems())
        {
            _cells[i].SetItem(baseItem);
            i++;
        }
    }
}
