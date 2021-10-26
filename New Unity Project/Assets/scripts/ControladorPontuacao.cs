using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControladorPontuacao
{



    private static int pontuacao;

    public static int Pontuacao
    {
        get
        {
            return Pontuacao;
        }
        set
        {
            Pontuacao = value;
            if(pontuacao < 0 )
            {
                Pontuacao = 0;
            }
        }
    }
}
   

