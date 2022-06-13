using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulha : MonoBehaviour
{
     
    public float vely, velx;
    public bool moveY, moveX;

    public bool proto;
    void Start()
    {
             

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void FixedUpdate()
    {
        if (moveY)
        {
            transform.Translate(0, vely * Time.deltaTime, 0);
        }
        else if (moveX)
        {
            transform.Translate(velx * Time.deltaTime, 0, 0);
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Borda") )
        {
            inverte();
            Debug.Log("colidiu");
        }
      
    }

    public void inverte()
    {
        if (proto)
        {
            this.transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        }
        vely = -vely;
        velx = -velx;
        
        
    }
}
