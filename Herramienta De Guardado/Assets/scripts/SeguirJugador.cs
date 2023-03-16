using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* este script permite que la c�mara siga al jugador en su movimiento la variable "jugador" 
 se define como un transform, y se asigna el objeto del jugador en el inspector en el m�todo update, 
 se actualiza la posici�n de la c�mara a la posici�n actual del jugador, pero manteniendo la misma coordenada 
 Z de la c�mara */
public class SeguirJugador : MonoBehaviour
{
    public Transform jugador;

    void Update()
    {
        // Actualizar la posici�n de la c�mara a la posici�n del jugador
        transform.position = new Vector3(jugador.position.x, jugador.position.y, transform.position.z);
    }
}
