using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private float speed = 6;
    private float speedr = 120;
    private GameObject player;
    private float distance;
    private PlayerController playerController;

    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        // Obtenemos la dirección del jugador
        Vector3 direction = player.transform.position - transform.position;
        direction.z = 0;

        // Calculamos el ángulo de rotación necesario para mirar al jugador
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Establecemos la rotación de la nave
        transform.rotation = Quaternion.Euler(0, 0, rotationZ - 90);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            playerController.Speed = 5;
            playerController.RecibirDaño(1);
            Invoke("ResetPlayerSpeed", 1);
            // Obtener el componente Sprite Renderer
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            // Asignar null al sprite para quitarlo
            spriteRenderer.sprite = null;
        }
    }

    void ResetPlayerSpeed()
    {
        playerController.Speed = 8;
        Destroy(gameObject);
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= 20f)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.z = 0;

            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            Quaternion desiredRotation = Quaternion.Euler(0, 0, rotationZ - 90);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, speedr * Time.deltaTime);

            transform.Translate(0, speed * Time.deltaTime, 0);
        }
    }
}
