using Newtonsoft.Json;
using UnityEngine;

public class UserDataJsonStorage : IDynamicStorageActions<User>
{
    private const string PrefsUserKey = "CURRENT_USER";
    
    public void Save(User user)
    {
        PlayerPrefs.SetString(PrefsUserKey, JsonConvert.SerializeObject(user));
        PlayerPrefs.Save();
    }

    public User Load()
    {
        if (PlayerPrefs.HasKey(PrefsUserKey))
        {
            return JsonConvert.DeserializeObject<User>(PlayerPrefs.GetString(PrefsUserKey));
        }
        else
        {
            return null;
        }
    }
}