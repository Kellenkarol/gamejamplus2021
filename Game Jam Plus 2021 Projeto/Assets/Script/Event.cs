using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Event : MonoBehaviour
{
    public static event Action<Dialog> DialogEvent = delegate { };

    public static void OnDialogEvent(Dialog dialog)
    {
        DialogEvent?.Invoke(dialog);
    }
}
