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

    public static event Action<int> PersonageTakeDamage = delegate { };

    public static void OnPersonageTakeDamage(int life)
    {
        PersonageTakeDamage?.Invoke(life);
    }

    public static event Action PersonageDie = delegate { };

    public static void OnPersonageDie()
    {
        PersonageDie?.Invoke();
    }

    public static event Action<float> UIDefenseAmount = delegate { };

    public static void OnUIDefenseAmount(float value)
    {
        UIDefenseAmount?.Invoke(value);
    }
}
