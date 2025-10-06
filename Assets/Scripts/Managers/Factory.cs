using UnityEngine;

public class Factory : MonoBehaviour
{
    public static Factory Instance;

    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private CellChest _cellChestPrefab;
    [SerializeField] private Reliq _reliqPrefab;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Enemy _bossPrefab;
    [SerializeField] private Chest _chestPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public Cell CreateCell()
    {
        return Instantiate(_cellPrefab);
    }

    public CellChest CreateChestCell()
    {
        return Instantiate(_cellChestPrefab);
    }

    public Reliq CreateReliq()
    {
        return Instantiate(_reliqPrefab);
    }

    public Chest CreateChest(Transform parent)
    {
        return Instantiate(_chestPrefab, parent);
    }

    public Enemy CreateEnemy(Transform parent)
    {
        return Instantiate(_enemyPrefab, parent);
    }

    public Enemy CreateBoss(Transform parent)
    {
        return Instantiate(_bossPrefab, parent);
    }

    public float GetCellSize() => _cellPrefab.transform.localScale.x;
}
