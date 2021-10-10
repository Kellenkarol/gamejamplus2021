using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils;
public class ToggleScriptMusic : MonoBehaviour, IPointerDownHandler
{
    //Detect current clicks on the GameObject (the one with the script attached)
    [SerializeField] bool statusToggle;
    [SerializeField] AudioSource audioToggle;
    [SerializeField] Image image;
    [SerializeField] Array<Sprite> sprites;
    private void Start()
    {
        statusToggle = true;
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //Output the name of the GameObject that is being clicked
        statusToggle = !statusToggle;
        AudioManager.Instance.ChangeMusicStatus(statusToggle);
        if (statusToggle)
            image.sprite = sprites.GetElement(0);
        else
            image.sprite = sprites.GetElement(1);
        audioToggle.Play();
    }
}
