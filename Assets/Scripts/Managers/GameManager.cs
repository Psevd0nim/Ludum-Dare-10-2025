using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameUIController _gameUIController;
    [SerializeField] private InputController _inputController;
    [SerializeField] private LevelController _levelController;
    [SerializeField] private Factory _factory;
    [SerializeField] private Player _player;
    [SerializeField] private FightManager _fightManager;
    [SerializeField] private RoomManager _roomManager;

    private void Awake()
    {
        Application.targetFrameRate = 144;
    }

    private void Start()
    {
        InitGameLocator();
        StartInits();
        GameLocator.LevelController.StartLevel();
    }

    private void InitGameLocator()
    {
        GameLocator.Init(_gameUIController, _inputController, _levelController, _factory, GameData.Instance, _player, _fightManager, _roomManager);
    }

    private void StartInits()
    {
        GameLocator.LevelController.Init();
        GameLocator.GameUIController.Init();
    }
}

public static class GameLocator
{
    [Header("Managers")]
    public static GameUIController GameUIController { get; private set; }
    public static InputController InputController { get; private set; }
    public static LevelController LevelController { get; private set; }
    public static Factory Factory { get; private set; }
    public static GameData GameData { get; private set; }
    public static Player Player { get; private set; }
    public static FightManager FightManager { get; private set; }
    public static RoomManager RoomManager { get; private set; }

    public static void Init
        (GameUIController gameUIController, InputController inputController, 
        LevelController levelController, Factory factory, 
        GameData gameData, Player player,
        FightManager fightManager, RoomManager roomManager)
    {
        GameUIController = gameUIController;
        InputController = inputController;
        LevelController = levelController;
        Factory = factory;
        GameData = gameData;
        Player = player;
        FightManager = fightManager;
        RoomManager = roomManager;
    }
}