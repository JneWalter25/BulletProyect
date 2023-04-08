using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public enum TipoProyectil { Uno, Dos }; // Enumeración de los tipos de proyectil
    int cantidadDeDaño;
    public TipoProyectil tipoDeProyectil; // El tipo de proyectil que es este objeto
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        // Obtenemos la dirección del jugador
        Vector3 direction = player.transform.position - transform.position;
        direction.z = 0;

        // Calculamos el ángulo de rotación necesario para mirar al jugador
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Establecemos la rotación de la nave
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
