using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Quaternion soma;
    Transform trans;
    public AudioClip bonus;

    //Start is called before the first frame update
    void Start()
    {
       
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        

    }
    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(bonus, this.transform.position, 1.0f);
        }
    }
}
