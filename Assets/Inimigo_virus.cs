using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_virus : MonoBehaviour
{
    public int vida = 8;
   
    SpriteRenderer sprite;
    public Patrulha moveP;
    public GameObject[] spawnees;
    public GameObject shield;
    int randomInt;

    bool shieldDown;

    public AudioClip morte;
    // Start is called before the first frame update
    void Start()
    {
        shieldDown = false;
        shield = this.transform.Find("Shield").gameObject;
        sprite = GetComponent<SpriteRenderer>();
     
     
    }

    // Update is called once per frame
    void Update()
    {
        Color c = sprite.color;
        
        if (vida == 0)
        {
            AudioSource.PlayClipAtPoint(morte, this.transform.position, 1.0f);
            Destroy(this.gameObject);
            randomInt = Random.Range(0, spawnees.Length);
            Instantiate(spawnees[randomInt], this.transform.position, this.transform.rotation);
            Globais.PONTOS += 40;
        }     

        if (vida <= 3)
        {
            shield.SetActive(false);
        }
        sprite.color = c;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("BulletD"))
        {
            vida--;
        }
        if (col.CompareTag("BulletD") && vida == 3)
        {
            moveP.vely *= 2;
            
        }
  


    }


  
}
