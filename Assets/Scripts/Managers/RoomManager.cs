using System;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public event Action OnRoomPassed;

    [SerializeField] private GameObject _enemyParent;
    [SerializeField] private GameObject _chestParent;
    [SerializeField] private NextArrow _nextArrow;

    private void Start()
    {
        _nextArrow.OnPressed += RoomPassed;
    }

    public void Init()
    {
        SetNextArrowStatus(false);
        Clear();
    }

    public void MadeRoomByType(RoomType roomType)
    {
        switch(roomType)
        {
            case RoomType.Enemy:
                SpawnEnemy();
                break;
            case RoomType.Boss:
                SpawnBoss();
                break;
            case RoomType.Treasure:
                SpawnChest();
                break;
        }
    }

    private void SpawnEnemy()
    {
        Enemy enemy = GameLocator.Factory.CreateEnemy(_enemyParent.transform);
        enemy.OnZeroHealth += AfterEnemyDeath;
        GameLocator.FightManager.SetEnemy(enemy);
        GameLocator.GameUIController.SetActiveEnemyStats(true);
    }

    private void SpawnBoss()
    {
        Enemy enemy = GameLocator.Factory.CreateBoss(_enemyParent.transform);
        enemy.OnZeroHealth += AfterEnemyDeath;
        GameLocator.FightManager.SetEnemy(enemy);
        GameLocator.GameUIController.SetActiveEnemyStats(true);
    }

    private void AfterEnemyDeath(Enemy enemy)
    {
        GameLocator.FightManager.StopFight();
        SpawnChest();

        GameLocator.GameUIController.SetActiveEnemyStats(false);

        foreach (Transform child in _enemyParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void SpawnChest()
    {
        Chest chest = GameLocator.Factory.CreateChest(_chestParent.transform);
        chest.OnOpen += AfterOpenChest;
    }

    private void AfterOpenChest()
    {
        SetNextArrowStatus(true);
    }

    private void Clear()
    {
        foreach (Transform child in _enemyParent.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in _chestParent.transform)
        { 
            Destroy(child.gameObject); 
        }
    }

    private void SetNextArrowStatus(bool status)
    {
        _nextArrow.gameObject.SetActive(status);
    }

    private void RoomPassed()
    {
        OnRoomPassed?.Invoke();
    }
}
