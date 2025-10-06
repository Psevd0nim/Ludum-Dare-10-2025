using UnityEngine;
using UnityEngine.SceneManagement;

public class Tittle : MonoBehaviour
{
    private float time = 0;
    private bool _canSkip;

    public void Click()
    {
        if(_canSkip)
            SceneManager.LoadScene("Hub");
    }

    private void Update()
    {
        if (time > 2)
        {
            _canSkip = true;
        }

        if(time > 5)
            SceneManager.LoadScene("Hub");

        time += Time.deltaTime;
    }
}
