using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ui;
    public GameObject fimJogo;
    public GameObject hold;
    public GameObject tap;
    public Text prim;
    public Text segu;
    public Text terc;
    public Text ponto;
    public Jogador jogador;

    private void Start()
    {

       //PlayerPrefs.DeleteAll();
    }

    private void Update()
    {
        ponto.text = Globais.PONTOS.ToString();


        if (PlayerPrefs.HasKey("primeiro")) prim.text = "1° " + PlayerPrefs.GetInt("primeiro");
        if (PlayerPrefs.HasKey("segundo")) segu.text = "2° " + PlayerPrefs.GetInt("segundo");
        if (PlayerPrefs.HasKey("terceiro")) terc.text = "3° " + PlayerPrefs.GetInt("terceiro");
      
    }

    public void GameOver()
    {
        
        ui.SetActive(false);
        fimJogo.SetActive(true);
        hold.SetActive(false);
        tap.SetActive(false);
        if(jogador.transform.position.x >= 1500)
        {
            if(jogador.tempo1 >= 350)
            {
                GravaPontos(Globais.PONTOS);
                ponto.text = Globais.PONTOS.ToString() + " X1";
            }

            else if (jogador.tempo1 >= 290 && jogador.tempo1 <= 350)
            {
                GravaPontos(Globais.PONTOS * 2);
                ponto.text = Globais.PONTOS.ToString() + " X2";
            }

            else if (jogador.tempo1 <= 290)
            {
                GravaPontos(Globais.PONTOS * 3);
                ponto.text = Globais.PONTOS.ToString() + " X3";
            }
        }
        else GravaPontos(Globais.PONTOS);


    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void CloseGame()
    {
        Debug.Log("SAI DO JOGO");
        Application.Quit();
    }

    public void GravaPontos(int score)
    {
        int prim, seg, ter;
        prim = 0;
        seg = 0;
        ter = 0;
     
        if (PlayerPrefs.HasKey("primeiro")) prim = PlayerPrefs.GetInt("primeiro", 0);
        if (PlayerPrefs.HasKey("segundo")) seg = PlayerPrefs.GetInt("segundo", 0);
        if (PlayerPrefs.HasKey("terceiro")) ter = PlayerPrefs.GetInt("terceiro", 0);

        if (score == prim || score == seg || score == ter) { }
        else if (score > prim)
        {
            PlayerPrefs.SetInt("primeiro", score);
            PlayerPrefs.SetInt("segundo", prim);
            PlayerPrefs.SetInt("terceiro", seg);
        }
        else if (score > seg)
        {
            PlayerPrefs.SetInt("segundo", score);
            PlayerPrefs.SetInt("terceiro", seg);
        }
        else if (score > ter)
            PlayerPrefs.SetInt("terceiro", score);
 
    }

    
    
    

}
