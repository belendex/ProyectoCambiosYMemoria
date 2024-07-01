using Cinemachine;
using System.Collections;
using UnityEngine;

public class ActivarParticulas : MonoBehaviour
{
    // Referencia al sistema de part�culas
    public GameObject sistemaParticulasPropio;
    public GameObject sistemaParticulas2;
    public GameObject sistemaParticulas3;
    public GameObject sistemaParticulas4;
    public GameObject sistemaParticulas5;
    public CinemachineVirtualCamera virtualCameraPlayer;
    public CinemachineVirtualCamera virtualCameraCinematic;
    public scr droneScript;
    

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entr� en el trigger tiene la etiqueta "bullet"
        if (other.CompareTag("bullet"))
        {
            // Activar el sistema de part�culas si est� desactivado
            if (!sistemaParticulasPropio.activeSelf)
            {
                sistemaParticulasPropio.SetActive(true);
                
                if(sistemaParticulas2.activeSelf && sistemaParticulas3.activeSelf && sistemaParticulas4.activeSelf && sistemaParticulas5.activeSelf) 
                {
                    virtualCameraPlayer.enabled = false;
                    virtualCameraCinematic.enabled = true;
                    StartCoroutine(FallDroneAnim());
                }
            }
        }
    }

    IEnumerator FallDroneAnim()
    {
        yield return new WaitForSeconds(1.2f);
        droneScript.FallDrone();
    }
}
