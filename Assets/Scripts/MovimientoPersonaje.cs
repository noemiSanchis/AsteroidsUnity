using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MovimientoPersonaje : MonoBehaviour
   
{
    public float speed = 10;
    Rigidbody2D rb;
    Animator anim;
    public GameObject[] hearts;
    CircleCollider2D collider;
    SpriteRenderer sprite;
    public float rotationSpeed = 10;
    public GameObject bala;
    public GameObject boquilla;
    public GameObject ParticulasMuerte;

void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            rb.AddForce(transform.up * vertical * speed * Time.deltaTime);
            anim.SetBool("Impulsing", true);
        }
        else
        {
            anim.SetBool("Impulsing", true);
        }

        float horizontal = Input.GetAxis("Horizontal");

        Vector3 moveRote = new Vector3(0, 0, horizontal);
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, horizontal * rotationSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            GameObject temp= Instantiate(bala, boquilla.transform.position, transform.rotation);
            Destroy(temp, 1.5F);
        }

    }

    public void Muerte()
    {
        GameManager.instance.vidas -= 1;
        GameObject temp = Instantiate(ParticulasMuerte, transform.position, transform.rotation);
        Destroy(temp, 2.5f);
        if (GameManager.instance.vidas < 1)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(Respawn_Coroutine());

        }
        if (GameManager.instance.vidas < 3)
        {
            hearts[0].gameObject.SetActive(false);
        }
        if (GameManager.instance.vidas < 2)
        {
            hearts[1].gameObject.SetActive(false);

        }
        if (GameManager.instance.vidas < 1)
        {
            hearts[2].gameObject.SetActive(false);

        }

        /* Invencible*/

        IEnumerator Respawn_Coroutine()
        {
            collider.enabled = false;
            sprite.enabled = false;
            yield return new WaitForSeconds(2);
            sprite.enabled = true;
            transform.position = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(0, 0);
            yield return new WaitForSeconds(2);
            collider.enabled = true;
        }


        if (GameManager.instance.vidas < 1)
        {
            Debug.Log("MUERTO");
            Destroy(gameObject);
            Time.timeScale = 0;
        }
        
    }

}
