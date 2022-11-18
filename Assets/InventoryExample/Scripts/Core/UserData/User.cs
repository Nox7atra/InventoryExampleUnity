using System;
using Newtonsoft.Json;

[Serializable]
public class User
{
    private static User _Current;
    public static User Current
    {
        get
        {
            if (_Current == null)
            {
                if (!Load())
                {
                    CreateUser();
                }
            }
            return _Current;
        }
    }

    [JsonProperty] private Inventory _inventory;
    public Inventory Inventory => _inventory;

    private static bool Load()
    {
        var data = Storages.Dynamic.UserStorage.Load();

        if (data == null)
        {
            return false;
        }
        else
        {
            _Current = data;
            _Current._inventory.OnChange += Save;
            return true;
        }
    }
    public static void Save()
    {
        Storages.Dynamic.UserStorage.Save(_Current);
    }

    public static void CreateUser()
    {
        _Current = new User();
        _Current._inventory = new Inventory(20);
        _Current._inventory.Add(0, new BaseItem()
        {
            ID = 0
        });
        _Current._inventory.Add(1, new BaseItem()
        {
            ID = 1
        });
        _Current._inventory.Add(2, new BaseItem()
        {
            ID = 2
        });
        Save();
        _Current._inventory.OnChange += Save;
    }
}
