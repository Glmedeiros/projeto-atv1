using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float velocidadeY;


    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody.velocity = new Vector2(0, this.velocidadeY);
    }

    private void Update()
    {
        Camera camera = Camera.main;
        Vector3 posicaonaCamera = camera.WorldToViewportPoint(this.transform.position);
        //saiu da tela pela posicao superior
        if(posicaonaCamera.y > 1)
        {
            //destroi o proprio laser para evitar excesso de memoria no jogo pq cria varios tiros toda hora
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Inimigo"))
        {
            /*destroi so o inimigo
            Destroy(collision.gameObject);
            destroi o proprio laser
            Destroy(this.gameObject);
            */
            Inimigo inimigo = collision.GetComponent<Inimigo>();
            inimigo.ReceberDano();//parte da bool no inimigo(destruir)
            Destroy(this.gameObject);

        }
    }

}
