using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PersonageUI : MonoBehaviour
{
    public Text texto;

    private void Start()
    {
        Event.PersonageTakeDamage += UpdateUI;
        Event.PersonageDie += PersonageDie;
    }
    public void UpdateUI(int lifeValue)
    {
        texto.text = "" + lifeValue;
    }

    public void PersonageDie()
    {
        texto.text = "" + 0;
    }
}
