using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int vidas;
    public int puntuacion;
    private void Awake()
    {
        instance = this; 
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }

}
