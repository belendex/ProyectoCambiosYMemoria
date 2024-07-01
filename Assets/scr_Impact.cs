using UnityEngine;

public class ChildCollisionHandler : MonoBehaviour
{
    public GameObject particleSystemObject; // Referencia al sistema de part�culas
    public float delayAfterBulletCollision = 2f; // Retraso despu�s de recibir una colisi�n de bala
    public float vibrationIntensity = 0.5f; // Intensidad de la vibraci�n en rotate
    private float delayTimer = 0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            // Activar el sistema de part�culas
            particleSystemObject.SetActive(true);

            // Aplicar un retraso en el movimiento del objeto
            delayTimer = delayAfterBulletCollision;

            // A�adir vibraci�n al objeto
            transform.parent.Rotate(Random.insideUnitSphere * vibrationIntensity);
        }
    }

    void Update()
    {
        // Si hay un retraso, disminuir el temporizador
        if (delayTimer > 0f)
        {
            delayTimer -= Time.deltaTime;
        }
        else
        {
            // Desactivar el sistema de part�culas despu�s del retraso
            particleSystemObject.SetActive(false);
        }
    }
}
