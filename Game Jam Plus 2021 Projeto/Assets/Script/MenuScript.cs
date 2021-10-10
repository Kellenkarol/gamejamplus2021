using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
using UnityEditor;
public class MenuScript : MonoBehaviour
{
    public Array<GameObject> telas;
    public void BTN_Play()
    {
        SceneManager.LoadScene("Cena 1");
    }
    public void BTN_Settings()
    {
        SelectScreen(1);
    }
    public void BTN_Credits()
    {
        SelectScreen(2);

    }
    public void BTN_Home()
    {
        SelectScreen(0);
    }
    public void BTN_Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
             Application.Quit();
        #endif
    }

    public void SelectScreen(int i)
    {
        telas.GetElement(0).SetActive(false);
        telas.GetElement(1).SetActive(false);
        telas.GetElement(2).SetActive(false);

        telas.GetElement(i).SetActive(true);

    }
}
