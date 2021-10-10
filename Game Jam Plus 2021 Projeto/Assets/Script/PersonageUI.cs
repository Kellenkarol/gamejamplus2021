using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PersonageUI : MonoBehaviour
{
    public Text texto;
    public Image DefenseHabilityUI;
    private void Start()
    {
        Event.PersonageTakeDamage += UpdateUI;
        Event.PersonageDie += PersonageDie;
        Event.UIDefenseAmount += UpdateDefenseAmount;
    }
    public void UpdateUI(int lifeValue)
    {
        texto.text = "" + lifeValue;
    }

    public void PersonageDie()
    {
        texto.text = "" + 0;
    }

    public void UpdateDefenseAmount(float value)
    {
        DefenseHabilityUI.fillAmount = value;
    }
}
