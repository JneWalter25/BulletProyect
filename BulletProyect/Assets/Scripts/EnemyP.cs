using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyP : MonoBehaviour
{
    private GameObject player;
    private float distance;
    private float speed = 5;
    private float speedr;
    public GameObject projectile1;
    public GameObject projectile2;
    private float lastShotTime;
    private float lastBoatTime;
    private Vector3 shootDirection;
    private float projectileSpeed1 = 10;
    private float projectileSpeed2 = 9;
    private float timeExist = 4;
    public GameObject botecito;
    private Vector3 genPosition;
    private Vector3 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SavePos", 0, 5);
        player = GameObject.Find("Player");
        // Obtenemos la direcci�n del jugador
        Vector3 direction = player.transform.position - transform.position;
        direction.z = 0;

        // Calculamos el �ngulo de rotaci�n necesario para mirar al jugador
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Establecemos la rotaci�n de la nave
        transform.rotation = Quaternion.Euler(0, 0, rotationZ - 90);
    }

    void SavePos()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= 7.5)
        {
            speedr = 40;
            // Obtener la direcci�n hacia el jugador
            Vector3 direction = player.transform.position - transform.position;
            direction.z = 0; // Establecer la direcci�n en el plano XY

            // Calcular el �ngulo de rotaci�n en el eje Z
            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Calcular la rotaci�n deseada
            Quaternion desiredRotation = Quaternion.Euler(0, 0, rotationZ - 90);

            // Aplicar la rotaci�n a una velocidad constante
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, speedr * Time.deltaTime);

            // Spawnear bote
            if (Time.time - lastBoatTime > 3f) // Solo si ha pasado 3 segundos desde el �ltimo barquito
            {
                shootDirection = (player.transform.position - transform.position).normalized;
                // Generar un bote
                genPosition = transform.position + new Vector3(0, 1, 0);
                GameObject boat = Instantiate(botecito, genPosition, Quaternion.identity);
                lastBoatTime = Time.time; // Actualizar el tiempo del �ltimo spawn

            }

            // Comprobar si est� de frente al jugador
            if (Mathf.Abs(transform.rotation.eulerAngles.z - desiredRotation.eulerAngles.z) < 10f)
            {
                if (Time.time - lastShotTime > 0.5f) // Solo si ha pasado 0.5 segundos desde el �ltimo disparo
                {
                    shootDirection = (player.transform.position - transform.position).normalized;
                    // Generar un disparo
                    GameObject bullet = Instantiate(projectile1, transform.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * projectileSpeed1;
                    lastShotTime = Time.time; // Actualizar el tiempo del �ltimo disparo
                    Destroy(bullet, timeExist);
                }
            }
            else
            {
                if (Time.time - lastShotTime > 1f) // Solo si ha pasado 1 segundo desde el �ltimo disparo
                {
                    shootDirection = (player.transform.position - transform.position).normalized;
                    // Generar un disparo
                    GameObject bullet2 = Instantiate(projectile2, transform.position, Quaternion.identity);
                    bullet2.GetComponent<Rigidbody2D>().velocity = shootDirection * projectileSpeed2;
                    lastShotTime = Time.time; // Actualizar el tiempo del �ltimo disparo
                    Destroy(bullet2, timeExist);
                }
            }
        }
        if (distance > 7.5 && distance <= 15f)
        {
            speedr = 110;
            // Obtener la direcci�n hacia el jugador
            Vector3 direction = player.transform.position - transform.position;
            direction.z = 0; // Establecer la direcci�n en el plano XY

            // Calcular el �ngulo de rotaci�n en el eje Z
            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Calcular la rotaci�n deseada
            Quaternion desiredRotation = Quaternion.Euler(0, 0, rotationZ - 90);

            // Aplicar la rotaci�n a una velocidad constante
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, speedr * Time.deltaTime);

            // Mover hacia el jugador
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (previousPosition == transform.position && Time.time - lastShotTime > 20)
        {
            Destroy(gameObject);
        }

    }
}
