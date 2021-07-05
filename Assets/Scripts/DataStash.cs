using UnityEngine;

public class DataStash : MonoBehaviour
{
    private AccelByte.Api.User AccelByteUser;

    //Lazy singleton
    private static DataStash Instance;
    public static DataStash GetInstance()
    {
        return Instance;
    }

    //Persistent data store across the game
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
    }

    void Start()
    {
        AccelByteUser = AccelByte.Api.AccelBytePlugin.GetUser();
    }

    //Cleanup
    void OnDestroy()
    {
        Instance = null;
    }

    public AccelByte.Api.User GetAccelByteUser()
    {
        return AccelByteUser;
    }
}
