using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnZeroHealth;

    public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }
    public float Damage { get; private set; }
    public float Shields { get; private set; }

    public float maxHealth;
    public float damage;
    public float shields;

    private void Start()
    {
        ChangeValueByType(StatType.MaxHealth, maxHealth);
        ChangeValueByType(StatType.CurrentHealth, maxHealth);
        ChangeValueByType(StatType.Damage, damage);
        ChangeValueByType(StatType.Shields, shields);
    }

    public void ChangeValueByType(StatType type, float value)
    {
        switch (type)
        {
            case StatType.CurrentHealth:
                ChangeHealth(value);
                break;
            case StatType.MaxHealth:
                ChangeMaxHealth(value);
                break;
            case StatType.Damage:
                Damage += value;
                break;
            case StatType.Shields:
                Shields += value;
                break;
        }

        GameLocator.GameUIController.ChangeEnemyStatsViewByType(type, this);
    }

    private void ChangeHealth(float value)
    {
        CurrentHealth += value;
        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
            OnZeroHealth?.Invoke(this);
        }
    }

    [Button]
    public void TakeDamage(float value)
    {
        ChangeValueByType(StatType.CurrentHealth, -value);
    }

    public void DeathRattle()
    {
        Destroy(gameObject);
    }

    private void ChangeMaxHealth(float value)
    {
        MaxHealth += value;
    }
}
