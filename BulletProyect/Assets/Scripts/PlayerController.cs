using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    private float speed =8;
    private float turnSpeed = 130;
    private float horizontalInput;
    private float forwardInput;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Input de jugador
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");  
        //Movimiento hacia adelante
        transform.Translate(Vector2.up * Time.deltaTime * speed * forwardInput);
        //Rotacion del barco
        transform.Rotate(Vector3.back, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
