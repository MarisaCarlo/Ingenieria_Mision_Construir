using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    [Header("Configuración de Audio")]
    [SerializeField] private AudioClip sonidoRecoleccion; // 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detecta si lo toca el jugador
        if (collision.CompareTag("Player") || collision.GetComponent<ControlJugador>() != null)
        {
            // Reproduce el efecto de sonido antes de destruir el objeto
            if (sonidoRecoleccion != null)
            {
                AudioSource.PlayClipAtPoint(sonidoRecoleccion, transform.position);
            }

            Destroy(gameObject);
        }
    }
}