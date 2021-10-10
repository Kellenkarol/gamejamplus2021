using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Event : MonoBehaviour
{
    public static event Action<Dialog,int> DialogEvent = delegate { };

    public static void OnDialogEvent(Dialog dialog,int dialogNumber)
    {
        DialogEvent?.Invoke(dialog,dialogNumber);
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

    public static event Action<Habilidades.Habilidade> GainHabilidade = delegate { };

    public static void OnGainHabilidade(Habilidades.Habilidade habilidade)
    {
        GainHabilidade?.Invoke(habilidade);
    }

    public static event Action InitialBossBattle = delegate { };

    public static void OnInitialBossBattle()
    {
        InitialBossBattle?.Invoke();
    }
}
