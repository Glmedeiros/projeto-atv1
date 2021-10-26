using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInimigo : MonoBehaviour
{
    public Inimigo inimigoPequenoPrefab;
    public Inimigo InimigoGrandePrefab;
    private float tempoDecorrido;


    // Start is called before the first frame update
    void Start()
    {

        this.tempoDecorrido = 0;




    }

    // Update is called once per frame
    void Update()
    {
        this.tempoDecorrido += Time.deltaTime;
        if(this.tempoDecorrido >= 1f)
        {
            this.tempoDecorrido = 0;

            Vector2 posicaoMaxima = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 posicaoMinima = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            float posicaoX = Random.Range(posicaoMinima.x, posicaoMaxima.x);

            Vector2 posicaoInimigo = new Vector2(posicaoX, posicaoMaxima.y);



            Inimigo prefabInimigo;


            //criance a chance de criar inimigos maiores com menos probabilidade q os pequenos
            float chance = Random.Range(0f, 100f);
            if(chance <= 25) // 25% de chances de criar um inimigo grande
            {
                prefabInimigo = this.InimigoGrandePrefab;   
            }
            else
            {
                prefabInimigo = this.inimigoPequenoPrefab;
            }

            



            //criar um novo inimigo
            Instantiate(prefabInimigo, posicaoInimigo, Quaternion.identity);
        }
    }
}
