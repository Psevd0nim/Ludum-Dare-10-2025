using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public PlayerStatsCurrent playerStats;

    private Vector2 _startPos;

    public void Init()
    {
        playerStats.OnZeroHealth += DeathRattle;
        _startPos = transform.localPosition;
    }

    public void SetDefaultPlayerStats()
    {
        List<PlayerStatData> listDefaultStats = GameData.Instance.playerConfig.playerStatsDefaultData.listStats;
        foreach(PlayerStatData playerStatData in listDefaultStats)
        {
            playerStats.ChangeValueByType(playerStatData.type, playerStatData.value);
        }
    }

    [Button]
    public void TakeDamage(float value)
    {
        playerStats.ChangeValueByType(StatType.CurrentHealth, -value + playerStats.Shields);
    }

    public void AttackAnim()
    {
        DOTween.Sequence()
            .Append(transform.DOLocalMove(transform.localPosition + new Vector3(0.2f, 0), 0.3f))
            .Append(transform.DOLocalMove(_startPos, 0.6f))
            .OnComplete(() => transform.localPosition = _startPos);
    }

    private void DeathRattle()
    {
        SceneManager.LoadScene("Tittle");
    }
}
