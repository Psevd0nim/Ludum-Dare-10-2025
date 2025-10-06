using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private GameObject _level;

    private RoomUI _lastRoom;

    public void Init()
    {
        GameLocator.Player.SetDefaultPlayerStats();
        MapInit();
        GameLocator.GameUIController._mapPanel.OnRoomChoosed += LoadRoomByType;
        GameLocator.RoomManager.OnRoomPassed += StartLevel;
        GameLocator.Player.Init();
    }

    public void StartLevel()
    {
        if (_lastRoom != null && _lastRoom.StageType == StageType.Four)
            SceneManager.LoadScene("Tittle");

        _level.SetActive(false);
        GameLocator.GameUIController._mapPanel.ShowAvailableRooms();
        GameLocator.GameUIController.SetMapStatus(true);
        GameLocator.RoomManager.Init();
        GameLocator.GameUIController.SetGamePanelStatus(false);
    }

    public void MapInit()
    {
        foreach(var room in GameLocator.GameUIController.GetMapRooms())
        {
            room.Init(_levelConfig.GetRoomTypeByStageType(room.StageType));
        }
        GameLocator.GameUIController._mapPanel.Init();
    }

    public void LoadRoomByType(RoomUI roomUI)
    {
        GameLocator.RoomManager.MadeRoomByType(roomUI.RoomType);
        _level.SetActive(true);
        GameLocator.GameUIController.SetMapStatus(false);
        GameLocator.GameUIController.SetGamePanelStatus(true);

        _lastRoom = roomUI;
    }
}
