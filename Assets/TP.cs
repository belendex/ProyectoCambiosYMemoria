using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform destination; // Objeto de destino donde se teletransportar� el jugador
    private bool canTeleport = false; // Variable de control para el teletransporte

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canTeleport==true ) // Comprueba si el objeto que ha entrado en el collider es el jugador y se permite teletransportar
        {
            Debug.Log("hola");
            TeleportPlayer(other.gameObject); // Llama a la funci�n para teletransportar al jugador
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Verifica si se ha presionado la tecla Q
        {
            canTeleport = true; // Permite el teletransporte al presionar la tecla Q
        }
    }
    private void TeleportPlayer(GameObject player)
    {
        player.transform.position = destination.position; // Teleporta al jugador a la posici�n del objeto de destino

        // Establecer el teletransporte como no permitido durante un breve per�odo de tiempo para evitar teletransportaciones consecutivas
        canTeleport = false;
        Invoke("ResetTeleport", 1f); // Cambia el valor de 1f seg�n sea necesario para ajustar el tiempo de espera entre teletransportes

        // Puedes a�adir aqu� efectos de sonido, part�culas, animaciones, etc., para mejorar la experiencia de teleportaci�n
    }

    private void ResetTeleport()
    {
        canTeleport = true;
    }
}