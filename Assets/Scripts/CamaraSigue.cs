using UnityEngine;

public class CamaraSigue : MonoBehaviour
{
    [SerializeField] private Transform objetivo;
    [SerializeField] private float suavidad = 0.125f;
    [SerializeField] private Vector3 desplazamiento = new Vector3(0, 1, -10);

    private void LateUpdate()
    {
        if (objetivo != null)
        {
            Vector3 posicionDeseada = objetivo.position + desplazamiento;
            Vector3 posicionSuave = Vector3.Lerp(transform.position, posicionDeseada, suavidad);
            transform.position = posicionSuave;
        }
    }
}