using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bulletDPrefab, bulletSPrefab, bulletBPrefab;
    public GameObject jogador;
    GameObject cannon;
    bool press;
    bool espera;
    bool esperaS;
    public float timer = 0.5f;
    public float timerS = 0.2f;

    public AudioClip shoot1;
    public AudioClip shoot2;
    public AudioClip shoot3;

    AudioSource audioPlayer;

    // Start is called before the first frame update

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        cannon = GetComponent<GameObject>();
        press = false;
        espera = true;
        esperaS = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!espera)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                espera = true;
                timer = 0.5f;
            }
           
        }

        if (!esperaS)
        {
            timerS -= Time.deltaTime;
            if (timerS <= 0)
            {
                esperaS = true;
                timerS = 0.2f;
            }

        }

    }

    public void shootBullet()
    {
        
        

        if (Jogador.estado == Globais.DAMAGESHOT && espera)
        {
            damageShot();
            Debug.Log("caraio");
            espera = false;
        }
        if (Jogador.estado == Globais.BURSTSHOT && espera)
        {
            burstShot();
            espera = false;
        }
        if (Jogador.estado == Globais.SUPERSHOT && esperaS)
        {
            superShot();
            esperaS = false;
        }
        
    }

    public void pressOn()
    {
        press = true;
    }

    public void pressOff()
    {
        press = false;
    }

    public void damageShot()
    {
        GameObject b = Instantiate(bulletDPrefab) as GameObject;
        b.transform.rotation = jogador.transform.rotation;
        b.transform.position = jogador.transform.position;
        audioPlayer.PlayOneShot(shoot2);
    }

    public void superShot()
    {
        
        GameObject a = Instantiate(bulletSPrefab) as GameObject;
        a.transform.rotation = jogador.transform.rotation;
        a.transform.position = jogador.transform.position;
        audioPlayer.PlayOneShot(shoot1);
    }

    public void burstShot()
    {
        GameObject a = Instantiate(bulletBPrefab) as GameObject;
        a.transform.rotation = jogador.transform.rotation;
        a.transform.position = jogador.transform.position;
        audioPlayer.PlayOneShot(shoot3);
    }


}
