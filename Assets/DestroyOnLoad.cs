using System.Collections;
using System.Collections.Generic;
using TouchScript.InputSources;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnLoad : MonoBehaviour
{
    StandardInput tS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        tS = FindObjectOfType<StandardInput>();
        Destroy(tS);
    }
}
