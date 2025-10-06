using UnityEngine;

public class BackpackManager : MonoBehaviour
{
    [SerializeField] private Backpack _backpack;

    private Cell _currentActiveCell;
    private Reliq _currentActiveReliq;

    private bool _reliqIsActive;

    private void Update()
    {
        if (_reliqIsActive)
            MoveReliq();
    }

    public void SetActiveReliq(Reliq reliq)
    {
        _currentActiveReliq = reliq;
        _reliqIsActive = true;
    }

    public void InputOff()
    {
        if (_currentActiveReliq == null)
            return;

        var hits = Physics2D.RaycastAll(InputController.Instance.WorldMousePos, Vector2.zero);
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("Cell"))
            {
                _currentActiveCell = hit.collider.GetComponent<Cell>();
            }
        }



        if (_currentActiveCell != null && _currentActiveReliq.TargetCell != _currentActiveCell && _currentActiveCell.TargetReliq == null)
        {
            _currentActiveCell.SetReliq(_currentActiveReliq);
            _currentActiveReliq.SetTargetCell(_currentActiveCell);
            _backpack.SetContentToBackpack(_currentActiveReliq.gameObject);
        }
        else
        {
            _currentActiveReliq.Move();
        }
        _currentActiveCell = null;
        _currentActiveReliq = null;
        _reliqIsActive = false;
    }

    private void MoveReliq()
    {
        _currentActiveReliq.transform.position = InputController.Instance.WorldMousePos;
    }
}
