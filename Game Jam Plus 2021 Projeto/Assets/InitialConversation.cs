using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InitialConversation : MonoBehaviour
{
    public Dialog dialogTeste;
    public Text text;
    int posTexto;
    private void Start()
    {
        StartCoroutine(ReadAllDialog(dialogTeste));
    }
    // Start is called before the first frame update
    IEnumerator ReadAllDialog(Dialog dialog)
    {
        for(int i=0;i< dialog.phrases.GetArrayLenght(); i++)
        {
            yield return StartCoroutine(ReadPhrase(dialog.phrases.GetElement(i)));
            yield return new WaitForSeconds(3);
            text.text = "";
        }
        yield return null;
    }
    IEnumerator ReadPhrase(Phrase phrase)
    {        
        string[] splitsPhrase = phrase.text.Split(' ');

        foreach(string splitPhrase in splitsPhrase)
        {
            text.text += splitPhrase+" ";
            yield return new WaitForSeconds(phrase.timecharactere);
        }
        yield return null;
    }
}
