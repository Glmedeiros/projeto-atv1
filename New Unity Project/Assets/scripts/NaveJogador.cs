using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJogador : MonoBehaviour
{

    public new Rigidbody2D rigidbody;
    public float velocidadeMovimento;
    
    public Laser laserPrefab;
    public float tempoEsperaTiro;
    private float intervaloTiro;


    private int vidas;

    private FimJogo telaFimJogo;

    // Start is called before the first frame update
    void Start()
    {
        this.vidas = 5;
        this.intervaloTiro = 0;
        ControladorPontuacao.Pontuacao = 0;

        GameObject fimJogoGameObject = GameObject.FindGameObjectWithTag("TelaFimJogo");
        this.telaFimJogo = fimJogoGameObject.GetComponent<FimJogo>();
        this.telaFimJogo.Esconder();

    }

    // Update is called once per frame
    void Update()
    {

        this.intervaloTiro += Time.deltaTime;
        if(this.intervaloTiro >= this.tempoEsperaTiro )
        {
            this.intervaloTiro = 0;
            //atirar
            Atirar();
        }



        float horizontal = Input.GetAxis("Horizontal");
        float velocidadeX = (horizontal * this.velocidadeMovimento);
        
        this.rigidbody.velocity = new Vector2(velocidadeX, 0);


        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Inimigo"))
        {
            Vida--;
            Inimigo inimigo = collision.GetComponent<Inimigo>();
            inimigo.Destruir(false);// parte da bool do inimigo(derrotado)
        }
    }// trigger para tirar vida do jogador e destruir inimigo que enconstou nele

    private void Atirar()
    {
        Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);

    }

    public int Vida
    {
        get
        {
            return this.vidas;
        }
        set
        {
            this.vidas = value;
            if(this.vidas < 0)
            {
                this.vidas = 0;
                this.gameObject.SetActive(false);//desativa o jogador para ali embaixo vir a tela de fim de jogo sem ficar mexendo o jogador e contando ponto
                //exibir tela de fim de jogo 
                
                telaFimJogo.Exibir();
            }
        }
    }// codigo para a vida, contagem, nao deixar ir para negativo e sempre parar no 0

}

