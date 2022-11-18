
public interface IDynamicStorageActions<T>
{
    void Save(T data);
    T Load();
}
