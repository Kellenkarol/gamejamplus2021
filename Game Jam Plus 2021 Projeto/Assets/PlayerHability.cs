using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
public class PlayerHability : MonoBehaviour
{
    [SerializeField]Array<Habilidades> habilidadesPersonagem;
    // Start is called before the first frame update
    public bool PossuiHabilidade(Habilidades.Habilidade habilUsada)
    {
        if (habilidadesPersonagem.GetArrayLenght() > 0) { 
            for (int i = 0; i < habilidadesPersonagem.GetArrayLenght(); i++)
            {
                if (habilidadesPersonagem.GetElement(i).habilidade == habilUsada)
                {
                    return true;
                }
            }
        }
    
        return false;
    }


}
[System.Serializable]
public class Habilidades
{
    public enum Habilidade { Pulo,Defesa}
    public Habilidade habilidade;
}
