using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FimJogo : MonoBehaviour
{


    public Text textoPontuacao;


   public void Exibir()// metodo para exibir a tela de fim de jogo
    {
        this.gameObject.SetActive(true);
        this.textoPontuacao.text = (ControladorPontuacao.Pontuacao + "x");
        Time.timeScale = 0;// pausa o jogo
    }


    public void Esconder()// metodo para esconder a tela de fim de jogo
    {
        this.gameObject.SetActive(false);
    }



    public void TentarNovamente()
    {
        Time.timeScale = 1; //despausa o jogo
        SceneManager.LoadScene("Fase01");
    }



}
