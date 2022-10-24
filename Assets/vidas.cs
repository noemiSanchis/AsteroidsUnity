using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] hearts;
    public int vida = 3;
    public GameObject personaje;
    
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
   
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Asteroid")
        {
            vida -= 1;
            Debug.Log(vida);
            if (vida < 3)
            {
                hearts[0].gameObject.SetActive(false);
            }
            if (vida < 2)
            {
                hearts[1].gameObject.SetActive(false);
            }
            if (vida < 1)
            {
                hearts[2].gameObject.SetActive(false);
            }
        }
    }
}
