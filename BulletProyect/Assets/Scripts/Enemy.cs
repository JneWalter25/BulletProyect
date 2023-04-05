using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    float distance;
    private float speed = 4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= 6)
        {
            // Obtener la dirección hacia el jugador
            Vector3 direction = player.transform.position - transform.position;
            direction.z = 0; // Establecer la dirección en el plano XY

            // Calcular el ángulo de rotación en el eje Z
            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Establecer la rotación del enemigo hacia el jugador
            transform.rotation = Quaternion.Euler(0, 0, rotationZ - 90);
        }
        if (distance > 6 && distance <= 14f)
        {
            // Obtener la dirección hacia el jugador
            Vector3 direction = player.transform.position - transform.position;
            direction.z = 0; // Establecer la dirección en el plano XY

            // Calcular el ángulo de rotación en el eje Z
            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Establecer la rotación del enemigo hacia el jugador
            transform.rotation = Quaternion.Euler(0, 0, rotationZ - 90);

            // Mover hacia el jugador
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}
