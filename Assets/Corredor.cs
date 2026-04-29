using TMPro;
using UnityEngine;

public class Corredor : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI textoPasos;

    float distance;
    float distanciaRecorrida = 0f;
    bool corriendo = false;
    bool llego = false;

    ControladorPosta controladorPosta;

    void Start()
    {
        controladorPosta = FindFirstObjectByType<ControladorPosta>();
    }

    void Update()
    {
        if (!corriendo) return;
        if (target == null) return;
        if (llego) return;

        float step = speed * Time.deltaTime;

        distance = Vector3.Distance(transform.position, target.position);

        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        distanciaRecorrida += step;
        textoPasos.text = Mathf.RoundToInt(distanciaRecorrida).ToString();

        if (distance < 0.1f)
        {
            llego = true;
            corriendo = false;
            controladorPosta.CorredorLlego();
        }
    }

    public void IniciarCarrera(Transform nuevoTarget, float nuevaVelocidad)
    {
        target = nuevoTarget;
        speed = nuevaVelocidad;
        distanciaRecorrida = 0f;
        llego = false;
        corriendo = true;
        textoPasos.text = "0";
    }

    public void Posicionarse(Vector3 posicionInicial)
    {
        transform.position = posicionInicial;
        distanciaRecorrida = 0f;
        llego = false;
        corriendo = false;
        textoPasos.text = "0";
    }
}