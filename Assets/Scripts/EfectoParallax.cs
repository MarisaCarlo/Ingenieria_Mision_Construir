using UnityEngine;

public class EfectoParallax : MonoBehaviour
{
    [Header("Configuración de Cámara y Movimiento")]
    [SerializeField] private Transform camara;
    [SerializeField] private float multiplicadorEfecto;

    private Vector3 ultimaPosicionCamara;

    private void Start()
    {
        if (camara == null)
        {
            camara = Camera.main.transform;
        }
        ultimaPosicionCamara = camara.position;
    }

    private void LateUpdate()
    {
        Vector3 movimientoCamara = camara.position - ultimaPosicionCamara;
        transform.position += new Vector3(movimientoCamara.x * multiplicadorEfecto, movimientoCamara.y * multiplicadorEfecto, 0);
        ultimaPosicionCamara = camara.position;
    }
}