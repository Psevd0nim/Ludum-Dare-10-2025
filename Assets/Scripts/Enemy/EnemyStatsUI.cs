using TMPro;
using UnityEngine;

public class EnemyStatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _shieldsText;

    public void ChangeStatsViewByType(StatType type, Enemy enemy)
    {
        switch (type)
        {
            case StatType.CurrentHealth:
                ChangeHealthView(enemy);
                break;
            case StatType.MaxHealth:
                ChangeHealthView(enemy);
                break;
            case StatType.Damage:
                _damageText.text = enemy.Damage.ToString();
                break;
            case StatType.Shields:
                _shieldsText.text = enemy.Shields.ToString();
                break;
        }
    }

    private void ChangeHealthView(Enemy enemy)
    {
        _healthText.text = $"{enemy.CurrentHealth:0.00}/{enemy.MaxHealth:0.00}";
    }
}
