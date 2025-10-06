using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static InputController Instance;

    public Vector2 WorldMousePos { get; private set; }

    [SerializeField] private BackpackManager _backpackManager;

    private Vector2 screenMousePos;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        CheckMouseInput();
    }

    public void Init()
    {

    }

    private void CheckMouseInput()
    {
        if (Mouse.current == null)
            return;

        CheckMousePos();
        CheckMouseDown();
        CheckMouseUp();
    }

    private void CheckMouseDown()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            var hits = Physics2D.RaycastAll(WorldMousePos, Vector2.zero);
            foreach (var hit in hits)
            {
                if (hit.collider.CompareTag("Reliq"))
                {
                    _backpackManager.SetActiveReliq(hit.collider.GetComponent<Reliq>());
                    break;
                }
            }
        }
    }

    private void CheckMouseUp()
    {
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            _backpackManager.InputOff();
        }
    }

    private void CheckMousePos()
    {
        screenMousePos = Mouse.current.position.value;
        WorldMousePos = Camera.main.ScreenToWorldPoint(screenMousePos);
    }
}
