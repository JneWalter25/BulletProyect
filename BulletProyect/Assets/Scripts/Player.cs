using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isPushedByBullet = false;
    private float pushTimeRemaining = 0f;
    public float pushDuration = 0.2f;
    public float pushForce = 5f;
    private Rigidbody2D rb;
    private Vector2 pushDirection;
    float explosionForce = 1000f; // Ajustar seg�n sea necesario
    float explosionRadius = 5f; // Ajustar seg�n sea necesario
    float explosionDistance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isPushedByBullet)
        {
            // Aplica la fuerza del proyectil al jugador mientras que el temporizador sigue activo
            if (pushTimeRemaining > 0)
            {
                rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
                pushTimeRemaining -= Time.fixedDeltaTime;
            }
            else
            {
                // Detener la fuerza del empuje una vez que el temporizador ha expirado
                isPushedByBullet = false;
                rb.velocity = Vector2.zero; // Establecer la velocidad del jugador en cero
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            // Ignorar la colisi�n f�sica con el proyectil
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            // Obtener la posici�n del jugador y del proyectil
            Vector2 playerPos = transform.position;
            Vector2 bulletPos = collision.gameObject.transform.position;

            // Calcular la direcci�n y la distancia entre el jugador y el proyectil
            Vector2 explosionDir = (playerPos - bulletPos).normalized;
            explosionDistance = Vector2.Distance(playerPos, bulletPos);

            // Aplicar la fuerza de la explosi�n en el punto de colisi�n
            rb.AddForce(explosionDir * explosionForce * (1 - explosionDistance / explosionRadius), ForceMode2D.Impulse);

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
