using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int life = 5; // Cantidad de vida inicial del jugador

    public void RecibirDa�o(int cantidad)
    {
        life -= cantidad;

        if (life <= 0)
        {
            // El jugador ha muerto, puedes agregar aqu� c�digo para manejar el game over
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
