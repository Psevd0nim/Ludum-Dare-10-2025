using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public Backpack Backpack { get; private set; }

    public PlayerConfig playerConfig;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetBackpack(Backpack backpack)
    {

    }

    private void DefaultInit()
    {

    }
}
