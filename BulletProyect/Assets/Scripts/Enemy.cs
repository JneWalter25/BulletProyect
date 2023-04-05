using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    float distance;
    private float speed = 5;
    private float speedr;

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
            speedr = 75;
            // Obtener la dirección hacia el jugador
            Vector3 direction = player.transform.position - transform.position;
            direction.z = 0; // Establecer la dirección en el plano XY

            // Calcular el ángulo de rotación en el eje Z
            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Calcular la rotación deseada
            Quaternion desiredRotation = Quaternion.Euler(0, 0, rotationZ - 90);

            // Aplicar la rotación a una velocidad constante
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, speedr * Time.deltaTime);
        }
        if (distance > 6 && distance <= 14f)
        {
            speedr = 140;
            // Obtener la dirección hacia el jugador
            Vector3 direction = player.transform.position - transform.position;
            direction.z = 0; // Establecer la dirección en el plano XY

            // Calcular el ángulo de rotación en el eje Z
            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Calcular la rotación deseada
            Quaternion desiredRotation = Quaternion.Euler(0, 0, rotationZ - 90);

            // Aplicar la rotación a una velocidad constante
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, speedr * Time.deltaTime);

            // Mover hacia el jugador
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
    }
}
