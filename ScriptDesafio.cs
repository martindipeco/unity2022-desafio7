using System;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDesafio : MonoBehaviour
{
    string gameObjectName = "   TRAP.SPIKES.FLOOR   ";

    void Start()
    {

        //pase por referencia
        // ver método "modifiCadena" al final
        modifiCadena(ref gameObjectName);
        Debug.Log(gameObjectName);



        // Seleccionar GameObject por nombre
        GameObject trapFloorSpikes = GameObject.Find("trap_floor_spikes");


        //modificar su localScale a 10 en los tres ejes
        trapFloorSpikes.transform.localScale = new Vector3(10, 10, 10);


        //Parte 2
        // para capturar el error, "envolvemos" el código que puede arrojar error dentro de un try

        try
        {
            GameObject targetGameObject2 = GameObject.Find("door1");
            targetGameObject2.gameObject.SetActive(false);
        }

        // luego capturamos el error con catch

        catch(NullReferenceException ex)
        {
            Debug.Log("Referencia a objeto no establecida como instancia de un objeto ScriptDesafio.Start () (en Activos/ScriptDesafio.cs:32). Original message: " + ex);
        }
    }

    public void modifiCadena(ref string gameObjectName)
    {
        // el método modifiCadena pasa a minusculas, corta espacio en blanco, reemplaza punto por guión bajo 
        gameObjectName = gameObjectName.ToLower().Trim().Replace('.', '_');

        //Finalmente enrocamos palabras con substrings y sus index
        //Substring lleva dos parámetros para crear la subcadena a partir de la original, index de inicio y longitud de extensión
        //Si se indica un solo parametro, lo toma como index de inicio y va hasta el final de la cadena
        //primero que salga del 0 y devuelva 4 posiciones (trap)
        //luego que salga del 11 y devuelva hasta el final (_floor)
        //finalmente que salga del 4 y devuelva 7 posiciones (_spikes)
        gameObjectName = gameObjectName.Substring(0,4) + gameObjectName.Substring(11) + gameObjectName.Substring(4,7);

    }
}