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
            inimigo.Destruir(true);//parte da bool no inimigo(destruir)
            Destroy(this.gameObject);

        }
    }

}
