using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Inimigo_bac : MonoBehaviour
{
    SpriteRenderer sprite;
    public int vida = 5;
    private Vector3 size;
    public GameObject[] spawnees;
    int randomInt;

    public AudioClip morte;
    // Start is called before the first frame update
    void Start()
    {
        size = transform.localScale;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vida == 5)
        {
            transform.localScale = size;
        }
        if(vida == 4)
        {
           transform.localScale = size * 0.85f;
        }
        if (vida == 3)
        {
            transform.localScale = size * 0.70f;
        }
        if (vida == 2)
        {
            transform.localScale = size * 0.55f;
        }
        if (vida == 1)
        {
            transform.localScale = size * 0.40f;
        }
        if (vida == 0)
        {
            AudioSource.PlayClipAtPoint(morte, this.transform.position, 1.0f);
            Globais.PONTOS += 35;
            Destroy(this.gameObject);
            randomInt = Random.Range(0, spawnees.Length);
            Instantiate(spawnees[randomInt], this.transform.position, this.transform.rotation);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("BulletD"))
        {
            damage();
        }
        
    }

    public void damage()
    {
        vida--;

    }
}
