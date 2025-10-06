using System.Collections;
using UnityEngine;

public class Reliq : MonoBehaviour
{
    public Cell TargetCell { get; private set; }

    [SerializeField] private float _timeMove;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private ViewConfig _viewConfig;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Coroutine _coroutine;

    public void Init()
    {
        spriteRenderer.sprite = _viewConfig.GetReliqSpriteByRandom();
    }

    public void SetTargetCell(Cell cell)
    {
        if (TargetCell != null)
            TargetCell.SetReliq(null);
        TargetCell = cell;
        Move();
    }

    public void Move()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(MoveToPos());
    }

    public void SetInterractive(bool canInterract)
    {
        _collider.enabled = canInterract;
    }

    private IEnumerator MoveToPos()
    {
        float time = 0;
        Vector2 startPos = transform.position;
        Vector2 endPos = TargetCell.transform.position;
        while (time < _timeMove)
        {
            yield return null;
            transform.position = Vector2.Lerp(startPos, endPos, time / _timeMove);
            time += Time.deltaTime;
        }
        transform.position = endPos;
    }
}
