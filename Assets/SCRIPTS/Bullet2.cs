using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    Transform bullet;
    Vector2 direcao;
    public float velocidade = 1.0f;
    public GameObject bulletSon;
    public float timer;
    public GameObject muzzle1;
    public GameObject muzzle2;
    public GameObject muzzle3;
    public GameObject muzzle4;
    public GameObject muzzle5;


    public AudioClip impacto;
    public AudioClip explodiu;
    // Start is called before the first frame update
    void Start()
    {

       
        bullet = GetComponent<Transform>();
        direcao = new Vector2(1, 0);

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;


        if (timer <= 0)
        {
            GameObject a = Instantiate(bulletSon) as GameObject;
            a.transform.rotation = muzzle1.transform.rotation;
            a.transform.position = muzzle1.transform.position;

            GameObject b = Instantiate(bulletSon) as GameObject;
            b.transform.rotation = muzzle2.transform.rotation;
            b.transform.position = muzzle2.transform.position;

            GameObject c = Instantiate(bulletSon) as GameObject;
            c.transform.rotation = muzzle3.transform.rotation;
            c.transform.position = muzzle3.transform.position;

            GameObject d = Instantiate(bulletSon) as GameObject;
            d.transform.rotation = muzzle4.transform.rotation;
            d.transform.position = muzzle4.transform.position;

            GameObject e = Instantiate(bulletSon) as GameObject;
            e.transform.rotation = muzzle5.transform.rotation;
            e.transform.position = muzzle5.transform.position;

            AudioSource.PlayClipAtPoint(explodiu, this.transform.position, 0.65f);

            Destroy(this.gameObject);
        }
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
