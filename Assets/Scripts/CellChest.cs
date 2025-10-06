using System;
using System.Collections;
using UnityEngine;

public class CellChest : Cell
{
    public event Action OnUnlock;

    [SerializeField] private GameObject _upLayer;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _unlockTime;

    public void SetInterReliq(bool inter)
    {
        TargetReliq.SetInterractive(inter);
    }

    public void StartUnlockAnim()
    {
        _animator.enabled = true;
        StartCoroutine(Unlock());
    }

    private IEnumerator Unlock()
    {
        yield return new WaitForSeconds(_unlockTime);
        _upLayer.SetActive(false);
        OnUnlock?.Invoke();
    }
}
