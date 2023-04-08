using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Variables
    private float speed = 9;
    private float turnSpeed = 130;
    private float horizontalInput;
    private float forwardInput;
    private bool isPaused = false;
    private GameObject pauseMenu;
    private GameObject gameOver;
    private TextMeshProUGUI vidaText;
    private int life = 10; // Cantidad de vida inicial del jugador

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        vidaText = GameObject.Find("Vida").GetComponent<TextMeshProUGUI>();
        gameOver = GameObject.Find("GameOver");
        pauseMenu = GameObject.Find("Pausa");
        Time.timeScale = 1; // Reanuda el juego
        pauseMenu.SetActive(false); // Desctiva el menú de pausa
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (isPaused)
            {
                // Si el juego ya estaba pausado, lo reanudamos
                Reanudar();
            }
            else
            {
                // Si el juego no estaba pausado, lo pausamos y activamos el menú de pausa
                Time.timeScale = 0; // Pausa el juego
                pauseMenu.SetActive(true); // Activa el menú de pausa
            }

            // Cambiamos el valor de la variable booleana
            isPaused = !isPaused;
        }
        //Input de jugador
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");  
        //Movimiento hacia adelante
        transform.Translate(Vector2.up * Time.deltaTime * speed * forwardInput);
        //Rotacion del barco
        transform.Rotate(Vector3.back, Time.deltaTime * turnSpeed * horizontalInput);
        vidaText.text = "Vida: " + life.ToString();
    }

    public void Reanudar()
    {
        Time.timeScale = 1; // Reanuda el juego
        pauseMenu.SetActive(false); // Desactiva el menú de pausa
    }


    public void RecibirDaño(int cantidad)
    {
        life -= cantidad;

        if (life <= 0)
        {
            Time.timeScale = 0; // Pausa el juego
            gameOver.SetActive(true);
        }
    }

    public void ReiniciarEscena()
    {
        Time.timeScale = 1; // Asegúrate de que el tiempo esté en normal antes de reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Carga la escena actual
    }

    public void Salir()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
