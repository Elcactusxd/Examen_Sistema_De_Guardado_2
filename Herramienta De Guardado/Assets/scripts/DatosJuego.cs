using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]


public class DatosJuego : MonoBehaviour
{
 /*este codigo define una variable pública de tipo Vector3 llamada "posicion", 
  utilizada para almacenar la posición del objeto en el juego*/


    public Vector3 posicion;


    /*antiguo metodopara deserializar un archivo JSON XnX*/
    /*

    public static DatosJuego FromJson(string json)
    {
        return JsonUtility.FromJson<DatosJuego>(json);
    }
    */
}


 