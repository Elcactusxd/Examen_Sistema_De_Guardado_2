using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* este script permite que la cámara siga al jugador en su movimiento la variable "jugador" 
 se define como un transform, y se asigna el objeto del jugador en el inspector en el método update, 
 se actualiza la posición de la cámara a la posición actual del jugador, pero manteniendo la misma coordenada 
 Z de la cámara */
public class SeguirJugador : MonoBehaviour
{
    public Transform jugador;

    void Update()
    {
        // Actualizar la posición de la cámara a la posición del jugador
        transform.position = new Vector3(jugador.position.x, jugador.position.y, transform.position.z);
    }
}
