using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public enum TipoProyectil { Uno, Dos }; // Enumeración de los tipos de proyectil
    int cantidadDeDaño;
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
                    cantidadDeDaño = 1;
                    break;
                case TipoProyectil.Dos:
                    cantidadDeDaño = 2;
                    break;
            }
            lifeComponent.RecibirDaño(cantidadDeDaño);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
