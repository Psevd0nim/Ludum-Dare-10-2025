using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Vector2 startPosValue;
    [SerializeField] private Vector2 endPosValue;

    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _shieldsText;

    public void ChangePlayerStatsViewByType(StatType type)
    {
        switch (type)
        {
            case StatType.CurrentHealth:
                ChangeHealthView();
                break;
            case StatType.MaxHealth:
                ChangeHealthView();
                break;
            case StatType.Damage:
                _damageText.text = GameLocator.Player.playerStats.Damage.ToString();
                break;
            case StatType.Shields:
                _shieldsText.text = GameLocator.Player.playerStats.Shields.ToString();
                break;
        }
    }

    private void ChangeHealthView()
    {
        _healthText.text = $"{GameLocator.Player.playerStats.CurrentHealth:0.00}/{GameLocator.Player.playerStats.MaxHealth:0.00}";
    }

    private bool _isShow;

    public void SetShowStatus()
    {
        if(_isShow)
        {
            _rectTransform.anchoredPosition = startPosValue;
            _isShow = false;
        }
        else
        {
            _rectTransform.anchoredPosition = endPosValue;
            _isShow = true;
        }
    }
}
