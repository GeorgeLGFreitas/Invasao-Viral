using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_proto : MonoBehaviour
{
    SpriteRenderer sprite;

    public int vida = 1;
    public int dano;
    public GameObject[] spawnees;
    int randomInt;

    public AudioClip morte;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
       

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletD"))
        {
            damage();
           
        }
        if(collision.CompareTag("Player"))
        {
          
            damage();
        }
       
    }

    public void damage()
    {
        dano = 1;
        vida -=  dano;

        if (vida == 0)
        {
            AudioSource.PlayClipAtPoint(morte, this.transform.position, 1.5f);
            Globais.PONTOS += 5;
            Destroy(this.gameObject);
            randomInt = Random.Range(0, spawnees.Length);
            Instantiate(spawnees[randomInt], this.transform.position, this.transform.rotation);
        } 
    }
    
}
