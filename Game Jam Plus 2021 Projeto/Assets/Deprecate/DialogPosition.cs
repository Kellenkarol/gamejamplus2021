using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DialogPosition : MonoBehaviour
{
    [SerializeField] Dialog dialog;
    [SerializeField] int dialogNumber;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Event.OnDialogEvent(dialog, dialogNumber);
            gameObject.SetActive(false);
        }
    }
}

