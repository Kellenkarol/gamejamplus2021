using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;
[System.Serializable]
public class Dialog
{
    public Array<Phrase> phrases;

    
}
[System.Serializable]
public class Phrase
{
    public PersonageDialog personageDialog;
    public string text;
    public float timecharactere;

}
