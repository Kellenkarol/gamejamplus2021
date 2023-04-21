using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonClick : MonoBehaviour, IPointerClickHandler
{
    public AudioSource audioButton;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        audioButton.Play();
        Debug.Log("Oie");
    }
}
