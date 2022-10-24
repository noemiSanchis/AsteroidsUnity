using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI tiempo;
    public TextMeshProUGUI vidas;
    public TextMeshProUGUI puntuacion;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        tiempo.text = Time.time.ToString("00:00");
        puntuacion.text = GameManager.instance.puntuacion.ToString();
        if(GameManager.instance.vidas < 1)
        {
            gameOver.gameObject.SetActive(true);
        }
    }
}
