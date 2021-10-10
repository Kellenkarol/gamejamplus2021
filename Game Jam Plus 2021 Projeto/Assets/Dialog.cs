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
    public Personage personage;
    public enum Side {Left,Right }
    public Side sideImage;
    public string text;
    public float timecharactere;

}
