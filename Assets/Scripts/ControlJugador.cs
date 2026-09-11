using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    [SerializeField] private float velocidadMovimiento = 8f;
    [SerializeField] private float fuerzaSalto = 12f;

    [Header("Detección de Suelo")]
    [SerializeField] private Transform sensorSuelo;
    [SerializeField] private float radioSensor = 0.2f;
    [SerializeField] private LayerMask capaSuelo;

    private Rigidbody2D rb;
    private Animator anim; // <-- 1. VARIABLE DECLARADA
    private float inputHorizontal;
    private bool enSuelo;
    private bool mirandoDerecha = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // <-- 2. COMPONENTE OBTENIDO
    }

    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        // Comprobar si el sensor colisiona con la Layer de Suelo
        enSuelo = Physics2D.OverlapCircle(sensorSuelo.position, radioSensor, capaSuelo);

        // Control de salto
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }

        GirarSprite();
        ActualizarAnimaciones();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(inputHorizontal * velocidadMovimiento, rb.linearVelocity.y);
    }

    private void ActualizarAnimaciones()
    {
        if (anim != null)
        {
            // Enviar parámetros al Animator Controller
            anim.SetFloat("Velocidad", Mathf.Abs(inputHorizontal));
            anim.SetBool("EnSuelo", enSuelo);
        }
    }

    private void GirarSprite()
    {
        if (inputHorizontal > 0 && !mirandoDerecha)
        {
            Voltear();
        }
        else if (inputHorizontal < 0 && mirandoDerecha)
        {
            Voltear();
        }
    }

    private void Voltear()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmosSelected()
    {
        if (sensorSuelo != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(sensorSuelo.position, radioSensor);
        }
    }
}