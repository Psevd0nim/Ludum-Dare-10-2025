using System.Collections;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    private Enemy _enemy;

    private bool _fightInProcess;

    private Coroutine _fightCoroutine;

    public void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
        StartFight();
    }

    public void StopFight()
    {
        if (_fightCoroutine != null)
            StopCoroutine(_fightCoroutine);
        _fightInProcess = false;
    }

    public void StartFight()
    {
        if (_fightCoroutine != null)
            StopCoroutine(_fightCoroutine);

        _fightInProcess = true;
        _fightCoroutine = StartCoroutine(FightCor());
    }

    private void Fight()
    {
        GameLocator.Player.TakeDamage(_enemy.Damage);

        if (GameLocator.Player.playerStats.CurrentHealth > 0)
        {
            _enemy.TakeDamage(GameLocator.Player.playerStats.Damage);
            GameLocator.Player.AttackAnim();
        }
    }

    private IEnumerator FightCor()
    {
        while (_fightInProcess)
        {
            yield return new WaitForSeconds(1);
            Fight();
        }
    }
}
