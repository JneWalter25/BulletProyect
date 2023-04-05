using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    float distance;
    private float speed = 5;
    private float speedr;
    public GameObject projectile1;
    public GameObject projectile2;
    private float lastShotTime;
    private Vector3 shootDirection;
    private float projectileSpeed1 = 8;
    private float projectileSpeed2 = 7;
    private float timeExist = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= 7.5)
        {
            speedr = 50;
            // Obtener la dirección hacia el jugador
            Vector3 direction = player.transform.position - transform.position;
            direction.z = 0; // Establecer la dirección en el plano XY

            // Calcular el ángulo de rotación en el eje Z
            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Calcular la rotación deseada
            Quaternion desiredRotation = Quaternion.Euler(0, 0, rotationZ - 90);

            // Aplicar la rotación a una velocidad constante
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, speedr * Time.deltaTime);

            // Comprobar si está de frente al jugador
            if (Mathf.Abs(transform.rotation.eulerAngles.z - desiredRotation.eulerAngles.z) < 10f)
            {
                if (Time.time - lastShotTime > 0.5f) // Solo si ha pasado 0.5 segundos desde el último disparo
                {
                    shootDirection = (player.transform.position - transform.position).normalized;
                    // Generar un disparo
                    GameObject bullet = Instantiate(projectile1, transform.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * projectileSpeed1;
                    lastShotTime = Time.time; // Actualizar el tiempo del último disparo
                    Destroy(bullet, timeExist);
                }
            }
            else
            {
                if (Time.time - lastShotTime > 1f) // Solo si ha pasado 1 segundo desde el último disparo
                {
                    shootDirection = (player.transform.position - transform.position).normalized;
                    // Generar un disparo
                    GameObject bullet2 = Instantiate(projectile2, transform.position, Quaternion.identity);
                    bullet2.GetComponent<Rigidbody2D>().velocity = shootDirection * projectileSpeed2;
                    lastShotTime = Time.time; // Actualizar el tiempo del último disparo
                    Destroy(bullet2, timeExist);
                }
            }
        }
        if (distance > 7.5 && distance <= 15f)
        {
            speedr = 120;
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
