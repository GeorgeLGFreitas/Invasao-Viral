using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    public Transform jogador;
    Rigidbody2D rb;
    Vector3 dirRot;
    Vector3 a;
    Quaternion roda;
    public float velocidade;
    private float ace;
    public float velocidadeRot = 1.0f;
    SpriteRenderer sprite;

    public static string estado;
    public static string estadoS;
    public GameObject shield;
    Shield shieldV;

    public Text pontosText;
    public Text tempoText;
    public float pontos;
    public float tempo;
    public int tempo1;
    public int vida;
    public bool jogando;
    public bool shieldB;
    public bool acabou;
    bool liga;
    float rotCam;
    Vector2 direcao;

    public float timer = 3.0f;
    float waitTime;

    Slider slider;
    GameManager gm;
    public Animator anim;

 
    
  

    void Start()
    {

        Globais.PONTOS = 0;
        vida = 1;
        acabou = false;
        waitTime = timer;
        ace = velocidade;
        rb = GetComponent<Rigidbody2D>(); 
        jogador = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        slider = FindObjectOfType<Slider>();
        estado = Globais.DAMAGESHOT;
        estadoS = Globais.NOSHIELD;
        dirRot = Vector3.zero;
        liga = true;
        direcao = new Vector2(1, 0);
        shieldB = false;
        jogando = true;
        gm = FindObjectOfType<GameManager>();

       
      

    }

    // Update is called once per frame
    void Update()
    {
        
        slider.value = jogador.position.x;

        tempo += Time.deltaTime;
        tempo1 = (int) tempo;
        pontos = Globais.PONTOS;
        pontosText.text = pontos.ToString();
        tempoText.text = tempo1.ToString() + ".s";

        /* if (timer <= 0)
         {
             Anda();
             Debug.Log("tempo");
             timer = waitTime;
         }*/

        if (vida <= 0)
        {
            sprite.color = new Color(1, 0, 0, 1);
            velocidade = 0f;
            shield.SetActive(false);

            if(!acabou)
            {
                gm.GameOver();
                acabou = true;
                
            }
              

        }
        if (vida == 1)
        {
            shieldB = false;
            shield.SetActive(false);

        }
        if (vida == 2)
        {
            shieldB = true;
            shield.SetActive(true);

        }
        if (liga)
        {
            direcao = new Vector2(1, 0);
        }
        if(!liga)
        {
            direcao = new Vector2(0, 0);
            //timer -= Time.deltaTime;
        }
       
      
        dirRot.z = -Input.acceleration.x;
        a = (0.1f * dirRot) + (0.9f * a);

        if (dirRot.sqrMagnitude > 1)
        {
            dirRot.Normalize();

        }
        
        dirRot *= Time.deltaTime * velocidadeRot;

        //jogador.Rotate (dirRot);
        //jogador.Rotate(a);

        if (jogando)
        {
            roda = new Quaternion(jogador.rotation.x, jogador.rotation.y, Mathf.Clamp(a.z, -0.7071f, 0.7071f), jogador.rotation.w);
        }
    }
    

    void FixedUpdate()
    {
        MoveJogador(direcao);

        jogador.rotation = roda;
    }

    public void MoveJogador(Vector2 direction)
    {
        jogador.Translate (direction * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Borda") && shieldB)
        {
            vida -= 2;
        }
        if (col.CompareTag("Borda") || col.CompareTag("Enemy"))
        {
            vida--;


            //Destroy(gameObject);
        }
        

        if (col.CompareTag("buffSshot"))
        {
            estado = Globais.SUPERSHOT;
            
        }
        if (col.CompareTag("buffSshot") && estado == Globais.SUPERSHOT)
        {
            Globais.PONTOS += 10;
    
        }

        if (col.CompareTag("buffDshot"))
        {
            estado = Globais.DAMAGESHOT;
     
        }
        if (col.CompareTag("buffDshot") && estado == Globais.DAMAGESHOT)
        {
            Globais.PONTOS += 10;
      
        }

        if (col.CompareTag("buffBshot"))
        {
            estado = Globais.BURSTSHOT;
        
        }
        if (col.CompareTag("buffBshot") && estado == Globais.BURSTSHOT)
        {
            Globais.PONTOS += 10;
         
        }

        if (col.CompareTag("Shield") && shieldB)
        {
            Globais.PONTOS += 10;
          
        }
        if (col.CompareTag("Shield") && !shieldB)
        {
            vida = 2;
            shieldB = true;
        
        }

    }
    
    public void Anda()
    {
        liga = true;
    }
    public void Para()
    {
        
        liga = false;

       
    }
    public void Acelera()
    {
        velocidade += 4;
        anim.SetBool("jatoOn", true);
    }

    public void Desacelera()
    {
        velocidade = ace;
        anim.SetBool("jatoOn", false);
    }



}
