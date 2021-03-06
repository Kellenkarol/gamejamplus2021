using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _dialogSystem;
    [SerializeField]Text text;
    [SerializeField] Image imagePerson;
    [SerializeField] Image BGPerson;
    private void Start()
    {
        Event.DialogEvent += InitialConversation;
    }
    public void InitialConversation (Dialog dialog,int dialogNumber)
    {

        _dialogSystem.SetActive(true);
        StartCoroutine(ReadAllDialog(dialog,dialogNumber));
    }
    IEnumerator ReadAllDialog(Dialog dialog,int dialogNumber)
    {
        Debug.Log(dialog.phrases.GetArrayLenght());
        for (int i = 0; i < dialog.phrases.GetArrayLenght(); i++)
        { 
            imagePerson.sprite = dialog.phrases.GetElement(i).personageDialog.personageImage;
            BGPerson.sprite = dialog.phrases.GetElement(i).personageDialog.bgImage;
            yield return StartCoroutine(ReadPhrase(dialog.phrases.GetElement(i)));
            yield return new WaitForSeconds(1);
             text.text = "";
        }
        _dialogSystem.SetActive(false);
        if (dialogNumber == 1)
        {
            Event.OnGainHabilidade(Habilidades.Habilidade.Pulo);
        }
        if (dialogNumber == 2)
        {
            Event.OnInitialBossBattle();
        }
        if (dialogNumber == 3)
        {
            Event.OnInitialBossBattle();
        }
        yield return null;
    }
    IEnumerator ReadPhrase(Phrase phrase)
    {
        string[] splitsPhrase = phrase.text.Split(' ');

        foreach (string splitPhrase in splitsPhrase)
        {
            text.text += splitPhrase + " ";
            yield return new WaitForSeconds(phrase.timecharactere);
        }
        yield return null;
    }
}
