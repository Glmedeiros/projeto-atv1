using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    public new Rigidbody2D rigidbody;
    public float velocidadeMinima;
    public float velocidadeMaxima;

    private float velocidadeY;
    public ParticleSystem particulaExplosaoPrefab;

    public int vidas;



    // Start is called before the first frame update
    void Start()
    {

        this.velocidadeY = Random.Range(this.velocidadeMinima, this.velocidadeMaxima);



        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);

        if(posicaoNaCamera.y < 0)
        {
            // inimigo saiu da area da camera
            NaveJogador jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<NaveJogador>();
            jogador.Vida--;
            Destruir(false);
        }



    }

    // Update is called once per frame
    void Update()
    {
        this.rigidbody.velocity = new Vector2(0, -this.velocidadeY);
    }



    public void ReceberDano()
    {
        this.vidas--;
        if(this.vidas <= 0)
        {
            Destruir(true);
        }
    }

    private void Destruir(bool derrotado)
    {
        if (derrotado)
        {
            //metodo para destruir inimigo e somar pontuacao
            ControladorPontuacao.Pontuacao++;
        }

        ParticleSystem particulaExplosao =  Instantiate(this.particulaExplosaoPrefab, this.transform.position, Quaternion.identity);
        Destroy(particulaExplosao.gameObject, 1f); //destroi a particula apos um segundo

        Destroy(this.gameObject);

    }
}
