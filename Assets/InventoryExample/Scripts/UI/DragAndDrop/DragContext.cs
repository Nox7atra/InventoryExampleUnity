using System;

public class DragContext<T> 
{
    private T _currentDraggable;
    private IDroppable<T> _container;
    public event Action<T> OnStartDrag;
    public event Action<T> OnDrag;
    public event Action<T> OnEndDrag;
    public void StartDrag(T draggable)
    {
        _currentDraggable = draggable;
        OnStartDrag?.Invoke(_currentDraggable);
    }

    public void EndDrag()
    {
        OnEndDrag?.Invoke(_currentDraggable);
        if (_container != null)
        {
            _container.OnDrop(_currentDraggable);
        }
        _currentDraggable = default(T);
    }

    public void ProcessDrag()
    {
        OnDrag?.Invoke(_currentDraggable);
    }
    public void EnterContainer(IDroppable<T> container)
    {
        _container = container;
    }

    public void ExitContainer(IDroppable<T> container)
    {
        if (_container == container)
        {
            _container = null;
        }
    }
}
