public class Storages
{
    public static IStorageActions<ItemVisualData> ItemsVisualDataStorage = new ItemsVisualDataStorage();
    
    public class Dynamic
    {
        public static IDynamicStorageActions<User> UserStorage = new UserDataJsonStorage();
    }
}
