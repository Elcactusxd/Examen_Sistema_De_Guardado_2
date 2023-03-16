using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;




/* este codigo controla la carga y el guardado de datos del juego, la posición del jugador, 
 también proporciona una forma de cargar o guardar manualmente estos datos utilizando las teclas "C" y "G"*/

public class ControladorDatosJuego : MonoBehaviour
{
    public GameObject jugador;
    public string claveDeGuardado = "PosicionJugador";

    /*aqui buscaremos a nuestro jugador para cargar los datos que tiene*/

    private void Awake()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
          CargarDatos();
    }
    /*como su nombre lo dice cargaremos los datos que se recojan de nuestro jugador*/
    private void CargarDatos()
    {
        if (PlayerPrefs.HasKey(claveDeGuardado))
        {
            string contenido = PlayerPrefs.GetString(claveDeGuardado);


            Vector3 posicion = Vector3.zero;
            string[] valores = contenido.Split(',');

            if (valores.Length == 3)
            {
                posicion.x = float.Parse(valores[0]);

                posicion.y = float.Parse(valores[1]);


                posicion.z = float.Parse(valores[2]);
            }

            else
            {
                Debug.LogError("Formato de datos incorrecto: " + contenido);
            }

            Debug.Log("Posicion Jugador :" + posicion);


             /*tendremos la posicion del objeto con los datos guardados*/
            jugador.transform.position = posicion;
        }

        else
        {
            Debug.Log("No se encontraron datos de guardado.");
        }

    }

    /*como el nombre lo indica se guardaran los datos de la posicion mas reciente de nuestro objeto*/

    private void GuardarDatos()
    {
        Vector3 posicion = jugador.transform.position;
        string contenido = posicion.x + "," + posicion.y + "," + posicion.z;
        PlayerPrefs.SetString(claveDeGuardado, contenido);
        Debug.Log("Datos guardados.");
    }

    /*aqui comprobaremos eluso de las teclas y si se han usado, 
     explica la funcion de cada una para guardar y cargar informacion*/
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CargarDatos();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GuardarDatos();
        }
    }
}





/*antigua opcion usando archivos JSON, todo un problema de cabeza xnx*/


/*public class ControladorDatosJuego : MonoBehaviour
{
    public GameObject jugador;
    public string archivoDeGuardado;
    public DatosJuego datosJuego = new DatosJuego();

    private void Awake()
    {
        archivoDeGuardado = Application.dataPath + "/datosJuego.json";
        jugador = GameObject.FindGameObjectWithTag("Player");

        CargarDatos();
    }
    private void CargarDatos()
    {
        if (File.Exists(archivoDeGuardado))
        {
            string contenido = File.ReadAllText(archivoDeGuardado);
            datosJuego = DatosJuego.FromJson(contenido);

            Debug.Log("Posicion Jugador :" + datosJuego.posicion);

            jugador.transform.position = datosJuego.posicion;
        }
        else
        {
            Debug.Log("El Archivo no existe");
        }
    }
*/

/* en busca de un metodo personalizado para deserializar los archivos jason */
/*private void CargarDatos()
{
    if (File.Exists(archivoDeGuardado))
    {
        string contenido = File.ReadAllText(archivoDeGuardado);
        datosJuego = JsonUtility.FromJson<DatosJuego>(contenido);

        Debug.Log("Posicion Jugador :" + datosJuego.posicion);

        jugador.transform.position = datosJuego.posicion;
    }
    else
    {

        Debug.Log("El Archivo no existe");

    }
}
*/
/* private void GuardarDatos()
 {
     DatosJuego nuevosDatos = new DatosJuego()
     {
         posicion = jugador.transform.position
     };
     string cadenaJSON = JsonUtility.ToJson(nuevosDatos);

     File.WriteAllText(archivoDeGuardado, cadenaJSON);
     Debug.Log("Archivo Guardado");
 }


 private void Update()
 {
     if (Input.GetKeyDown(KeyCode.C))
     {
         CargarDatos();
     }
     if (Input.GetKeyDown(KeyCode.G))
     {
         GuardarDatos();
     }
 }
}
*/

