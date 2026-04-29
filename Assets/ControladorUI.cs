using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ControladorUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoFinal;
    [SerializeField] Slider sliderVelocidad;
    [SerializeField] ControladorPosta controladorPosta;
    void Start()
    {
        textoFinal.gameObject.SetActive(false);

        sliderVelocidad.onValueChanged.AddListener(controladorPosta.CambiarVelocidad);
    }
    public void MostrarFinalizacion()
    {
        textoFinal.gameObject.SetActive(true);
    }
    public void Posicionarse()
    {
        textoFinal.gameObject.SetActive(false);
        controladorPosta.Posicionarse();
    }
    public void Correr()
    {
        controladorPosta.Correr();
    }
}