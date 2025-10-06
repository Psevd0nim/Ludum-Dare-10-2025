using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    public MapPanel _mapPanel;

    [SerializeField] private GameObject _gamePanel;

    [SerializeField] private PlayerStatsUI _playerStatsUI;
    [SerializeField] private EnemyStatsUI _enemyStatsUI;

    public void Init()
    {
        SetGamePanelStatus(false);
        SetMapStatus(false);
    }

    public void ChangePlayerStatsViewByType(StatType type)
    {
        _playerStatsUI.ChangePlayerStatsViewByType(type);
    }

    public void ChangeEnemyStatsViewByType(StatType statType, Enemy enemy)
    {
        _enemyStatsUI.ChangeStatsViewByType(statType, enemy);
    }

    public void SetActiveEnemyStats(bool status)
    {
        _enemyStatsUI.gameObject.SetActive(status);
    }

    public void SetMapStatus(bool status)
    {
        _mapPanel.gameObject.SetActive(status);
    }

    public List<RoomUI> GetMapRooms()
    {
        return _mapPanel._roomsList;
    }

    public void SetGamePanelStatus(bool status)
    {
        _gamePanel.SetActive(status);
    }
}
