
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float runMultiplier = 2f;
    public float rotationSpeed = 150f; // Velocidad de rotación

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Movimiento hacia adelante y atrás (W y S o Flecha Arriba/Abajo)
        float moveDirection = 0;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            moveDirection = 1;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            moveDirection = -1;

        // Ajustar velocidad de movimiento
        float finalSpeed = Input.GetKey(KeyCode.LeftShift) ? speed * runMultiplier : speed;
        Vector3 movement = transform.forward * moveDirection * finalSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // **ROTACIÓN con A y D o Flecha Izquierda/Derecha**
        float rotation = 0;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            rotation = -1;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            rotation = 1;

        // Aplicar rotación
        transform.Rotate(0, rotation * rotationSpeed * Time.fixedDeltaTime, 0);

        // **ROTACIÓN con el Mouse**
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed * Time.fixedDeltaTime, 0);
    }
}
