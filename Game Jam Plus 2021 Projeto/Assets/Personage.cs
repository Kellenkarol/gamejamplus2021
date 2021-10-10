using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "newPersonage", menuName = "ScriptableObjects/PersonageScriptableObject", order = 1)]
public class Personage : ScriptableObject
{
    public Image imagePersonageUI;
    public enum NamePersonage { Cabra_da_Peste, Ancião, Lobo_Mal, Lobinho };
    public NamePersonage name;
}
