using System;
using UnityEngine;

public class PlayerStatsCurrent : MonoBehaviour
{
    public event Action OnZeroHealth;

    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; }
    public float Damage { get; private set; }
    public float Shields { get; private set; }

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

        GameLocator.GameUIController.ChangePlayerStatsViewByType(type);
    }

    private void ChangeHealth(float value)
    {
        CurrentHealth += value;
        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
            OnZeroHealth?.Invoke();
        }
    }

    private void ChangeMaxHealth(float value)
    {
        MaxHealth += value;
    }
}

public enum StatType
{
    None, CurrentHealth, MaxHealth, Damage, Shields
}