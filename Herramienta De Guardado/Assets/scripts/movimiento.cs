using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidad = 5f;

    private Rigidbody2D rb;

    public float fuerzaDerrape = 0.5f;

    public float gravedadFija = -9.81f;




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector2.up * gravedadFija);

        float derrape = rb.velocity.magnitude * fuerzaDerrape;
        rb.AddForce(-rb.velocity.normalized * derrape);


        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(movimientoHorizontal, movimientoVertical);

        rb.MovePosition(rb.position + movimiento * velocidad * Time.fixedDeltaTime);
    }

}
