using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraVida : MonoBehaviour
{

    public GameObject[] barrasVermelhas;

    public void ExibirVida(int vidas)
    {
        for(int i = 0; i < this.barrasVermelhas.Length; i++)
        {
            if(i < vidas)
            {
                //ativas barra vermelha
                this.barrasVermelhas[i].SetActive(true);
            }
            else
            {
                //desativar barra vermelha
                this.barrasVermelhas[i].SetActive(false);
            }
        }
    }
}
