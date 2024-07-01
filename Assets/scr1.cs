using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scr1 : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float maxSpeed = 5f;
    public float acceleration = 2f;
    public float rotationSpeed = 90f; // Velocidad de rotaci�n en grados por segundo
    private Vector3 targetPosition;
    private float currentSpeed = 0f;

    void Start()
    {
        targetPosition = pointB.position;
    }

    void Update()
    {
        // Calcula la direcci�n y la distancia hacia el punto de destino
        Vector3 direction = (targetPosition - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, targetPosition);

        // Aplica aceleraci�n
        currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);

        // Mueve el objeto hacia el punto de destino a la velocidad actual
        transform.position += direction * currentSpeed * Time.deltaTime;

        // Si el objeto llega al punto de destino, cambia al siguiente punto y rota gradualmente
        if (distance < 0.1f)
        {
            if (targetPosition == pointA.position)
            {
                targetPosition = pointB.position;
            }
            else
            {
                targetPosition = pointA.position;
            }
            currentSpeed = 0f; // Reinicia la velocidad al cambiar de direcci�n
        }

        // Calcula la rotaci�n gradual del objeto hacia el punto de destino
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}