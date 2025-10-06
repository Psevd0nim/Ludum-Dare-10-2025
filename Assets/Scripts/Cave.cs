using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Cave : Clickable
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        //base.OnPointerDown(eventData);
        SceneManager.LoadScene("Game");
    }
}
