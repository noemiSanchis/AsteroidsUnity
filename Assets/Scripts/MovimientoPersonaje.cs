using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MovimientoPersonaje : MonoBehaviour
   
{
    public float speed = 10;
    Rigidbody2D rb;
    Animator anim;
    public float rotationSpeed = -0.3f;
// Start is called before the first frame update
void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

    }
}
