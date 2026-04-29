using System.Collections.Generic;
using UnityEngine;

public class ControladorPosta : MonoBehaviour
{
    [SerializeField] List<Transform> objetivos;
    [SerializeField] List<Corredor> corredores;
    [SerializeField] int cantidadVueltas = 2;
    [SerializeField] ControladorUI controladorUI;

    int corredorActual = 0;
    int vueltasCompletadas = 0;
    float velocidadActual = 1f;
    bool carreraActiva = false;

    List<Vector3> posicionesIniciales = new List<Vector3>();

    void Start()
    {
        foreach (Corredor c in corredores)
        {
            posicionesIniciales.Add(c.transform.position);
        }
    }

    public void Posicionarse()
    {
        carreraActiva = false;
        corredorActual = 0;
        vueltasCompletadas = 0;

        for (int i = 0; i < corredores.Count; i++)
        {
            corredores[i].Posicionarse(posicionesIniciales[i]);
        }
    }

    public void Correr()
    {
        if (carreraActiva) return;
        carreraActiva = true;
        corredorActual = 0;
        vueltasCompletadas = 0;
        corredores[0].IniciarCarrera(objetivos[0], velocidadActual);
    }

    public void CorredorLlego()
    {
        if (!carreraActiva) return;

        corredorActual++;

        if (corredorActual >= corredores.Count)
        {
            corredorActual = 0;
            vueltasCompletadas++;

            if (vueltasCompletadas >= cantidadVueltas)
            {
                carreraActiva = false;
                controladorUI.MostrarFinalizacion();
                return;
            }
        }

        int indiceObjetivo = (corredorActual + vueltasCompletadas) % objetivos.Count;

        corredores[corredorActual].IniciarCarrera(
            objetivos[indiceObjetivo],
            velocidadActual
        );
    }

    public void CambiarVelocidad(float nuevaVelocidad)
    {
        velocidadActual = nuevaVelocidad;
    }
}