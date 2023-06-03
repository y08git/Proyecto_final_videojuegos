using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f;

    private void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Vertical");
        float movimientoVertical = Input.GetAxis("Horizontal");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical) * velocidad * Time.deltaTime;
        transform.Translate(movimiento);
    }
}
