using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public enum TipoProyectil { Uno, Dos }; // Enumeraci�n de los tipos de proyectil
    int cantidadDeDa�o;
    public TipoProyectil tipoDeProyectil; // El tipo de proyectil que es este objeto
    public GameObject enemy;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el proyectil colisiona con otro objeto, destruye el proyectil
        Destroy(gameObject);

        // Obtener el componente Life del objeto del jugador y disminuir su vida
        Life lifeComponent = collision.gameObject.GetComponent<Life>();
        if (lifeComponent != null)
        {

            switch (tipoDeProyectil)
            {
                case TipoProyectil.Uno:
                    cantidadDeDa�o = 1;
                    break;
                case TipoProyectil.Dos:
                    cantidadDeDa�o = 2;
                    break;
            }
            lifeComponent.RecibirDa�o(cantidadDeDa�o);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
