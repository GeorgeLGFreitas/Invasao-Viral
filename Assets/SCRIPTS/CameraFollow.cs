using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject jogador;
    public GameObject holder;
    GameManager gm;
    Jogador jogaD;
    bool jogando;
    // Start is called before the first frame update
    void Start()
    {
        jogando = true;
        jogaD = FindObjectOfType<Jogador>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jogando)
        {
            holder.transform.position = new Vector3(jogador.transform.position.x + 5, jogador.transform.position.y, jogador.transform.position.z);
            holder.transform.rotation = jogador.transform.rotation;
        }
        else 
        { 
            holder.transform.position = new Vector3(1500, 15, 1);
            
        }

        if(jogador.transform.position.x >= 1500)
        {
            jogando = false;
            jogaD.jogando = false;
            gm.GameOver();
            jogaD.acabou = true;
        }
    }

    
}
