using UnityEngine;

public class enemyZombie : MonoBehaviour
{
    public string tagJugador = "Player";
    public string tagObstaculo = "Obstacle"; // Tag del obst�culo
    public float distanciaMinima = 5f;
    public float velocidadMovimiento = 3f;
    public float minY = 0f; // L�mite m�nimo en el eje Y
    public float maxY = 10f; // L�mite m�ximo en el eje Y
    public int life;
    public GameObject particles;

    private Transform jugador;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag(tagJugador).transform;
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia < distanciaMinima)
        {
            Vector3 direccion = (jugador.position - transform.position).normalized;
            transform.LookAt(-jugador.position);
            // Raycast para detectar obst�culos
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direccion, out hit, distanciaMinima))
            {
                // Verifica si el objeto detectado tiene la etiqueta de obst�culo
                if (hit.collider.CompareTag(tagObstaculo))
                {
                    // Detiene el movimiento si se detecta un obst�culo
                    return;
                }
            }

            // Restringe el movimiento vertical
            float newY = Mathf.Clamp(transform.position.y, minY, maxY);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // Mover el enemigo hacia el jugador
            transform.Translate(direccion * velocidadMovimiento * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            int dmg = other.gameObject.GetComponent<BulletScript>().damage;
            life = life - dmg;

            if (life < 0)
            {
                particles.SetActive(true);
                Destroy(gameObject, 1.7f);
            }
        }
    }
}

