using UnityEngine;

public class Cell : MonoBehaviour
{
    public Reliq TargetReliq { get; private set; }

    private int X;
    private int Y;

    public void Init(int x, int y)
    {
        X = x; Y = y;
    }

    public void SetReliq(Reliq reliq)
    {
        TargetReliq = reliq;
    }
}
