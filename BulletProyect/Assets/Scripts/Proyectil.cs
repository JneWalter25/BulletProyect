using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public enum TipoProyectil { Uno, Dos }; // Enumeraci�n de los tipos de proyectil
    int cantidadDeDa�o;
    public TipoProyectil tipoDeProyectil; // El tipo de proyectil que es este objeto
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        // Obtenemos la direcci�n del jugador
        Vector3 direction = player.transform.position - transform.position;
        direction.z = 0;

        // Calculamos el �ngulo de rotaci�n necesario para mirar al jugador
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Establecemos la rotaci�n de la nave
        transform.rotation = Quaternion.Euler(0, 0, rotationZ + 90);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el proyectil colisiona con otro objeto, destruye el proyectil
        Destroy(gameObject);

        // Obtener el componente Life del objeto del jugador y disminuir su vida
        PlayerController lifeComponent = collision.gameObject.GetComponent<PlayerController>();
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
