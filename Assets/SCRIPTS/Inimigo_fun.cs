using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_fun : MonoBehaviour
{
    public bool tresHit, doisHit, umHit;
    private int vida;
    public GameObject dHit, uHit;
    public GameObject[] spawnees;
    int randomInt;

    public AudioClip morte;
    // Start is called before the first frame update
    void Start()
    {
        if (tresHit)
        {
            doisHit = false;
            umHit = false;
            vida = 3;
        }

        if (doisHit)
        {
            tresHit = false;
            umHit = false;
            vida = 2;
        }

        if (umHit)
        {
            doisHit = false;
            tresHit = false;
            vida = 1;
        }
        

    }

    // Update is called once per frame
    void Update()
    {

        vida = vida;


    }

   
    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("BulletD"))
        {
            vida--;
            
            if(tresHit && vida <= 0)
            {
                Destroy(this.gameObject);
                DestroyTres();
                AudioSource.PlayClipAtPoint(morte, this.transform.position, 1.0f);

            }

            if (doisHit && vida <= 0)
            {
                Destroy(this.gameObject);
                DestroyDois();
                AudioSource.PlayClipAtPoint(morte, this.transform.position, 1.0f);
            }

            if (umHit && vida <= 0)
            {
                AudioSource.PlayClipAtPoint(morte, this.transform.position, 1.0f);
                Destroy(this.gameObject);
                DestroyUm();
             
            }
        }
        
    }

    public void divideTres()
    {
        GameObject b = Instantiate(dHit) as GameObject;
        b.GetComponent<Patrulha>().vely = -2;
        b.transform.position = new Vector3(transform.position.x + Random.Range(-1, -0), transform.position.y, 0);

        GameObject c = Instantiate(dHit) as GameObject;
        c.GetComponent<Patrulha>().vely = 2;
        c.transform.position = new Vector3(transform.position.x + Random.Range(0, 1), transform.position.y, 0);

        randomInt = Random.Range(0, spawnees.Length);
        Instantiate(spawnees[randomInt], this.transform.position, this.transform.rotation);

        
    }

    public void divideDois()
    {
        GameObject d = Instantiate(uHit) as GameObject;
        d.GetComponent<Patrulha>().vely = -3;
        d.transform.position = new Vector3(transform.position.x + Random.Range(-1, -2), transform.position.y, 0);

        GameObject e = Instantiate(uHit) as GameObject;
        e.GetComponent<Patrulha>().vely = 3;
        e.transform.position = new Vector3(transform.position.x + Random.Range(1, 2), transform.position.y, 0);

        randomInt = Random.Range(0, spawnees.Length);
        Instantiate(spawnees[randomInt], this.transform.position, this.transform.rotation);

       

    }

     public void divideUm()
     {

        randomInt = Random.Range(0, spawnees.Length);
        Instantiate(spawnees[randomInt], this.transform.position, this.transform.rotation);
        
     }

    private void DestroyTres()
    {
        Globais.PONTOS += 15;
        divideTres();
  
    }

    private void DestroyDois()
    {
        Globais.PONTOS += 10;
        divideDois();
  
    }

    private void DestroyUm()
    {
        Globais.PONTOS += 5;
        divideUm();
        
    }
}
