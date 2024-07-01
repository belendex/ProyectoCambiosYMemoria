using UnityEngine;

public class box : MonoBehaviour
{
    public ParticleSystem sistemaParticulas;
    private bool activado = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!activado && collision.gameObject.CompareTag("bullet"))
        {
            // Activa el sistema de part�culas
            sistemaParticulas.Play();
            activado = true;
        }
    }

    // M�todo para asignar el sistema de part�culas por c�digo
    public void AsignarSistemaParticulas(ParticleSystem sistema)
    {
        sistemaParticulas = sistema;
    }

    void Start()
    {
        // Det�n el sistema de part�culas al inicio
        sistemaParticulas.Stop();

        // Obt�n el componente ParticleSystem adjunto al objeto
        ParticleSystem sistema = GetComponent<ParticleSystem>();

        // Asigna el sistema de part�culas al script ActivarSistemaParticulas
        AsignarSistemaParticulas(sistema);
    }
}
