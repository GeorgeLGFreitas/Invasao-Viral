using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform bullet;
    
    public float velocidade = 1.0f;
    Vector2 direcao;
    public AudioClip impacto;
    


    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
        direcao = new Vector2(1, 0);
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MoveBullet(direcao);
    }


    public void MoveBullet(Vector2 direction)
    {
        bullet.Translate(direction * velocidade * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Borda"))
        {

            AudioSource.PlayClipAtPoint(impacto, this.transform.position, 1.0f);
             Destroy(this.gameObject);
            
        }
    }

 
  
}
