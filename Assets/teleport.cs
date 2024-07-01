using UnityEngine;

public class TP : MonoBehaviour
{
    public Transform destination; // Objeto de destino donde se teletransportar� el jugador

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el objeto que ha entrado en el collider es el jugador
        {
            TeleportPlayer(other.gameObject); // Llama a la funci�n para teletransportar al jugador
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        player.transform.position = destination.position; // Teleporta al jugador a la posici�n del objeto de destino
        // Aqu� puedes a�adir efectos de sonido, part�culas, animaciones, etc., para mejorar la experiencia de teleportaci�n
    }
}
