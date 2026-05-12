using UnityEngine;
using System.Collections;

public class DianaDinamica : MonoBehaviour
{
    public Transform izquierda;
    public Transform derecha;

    public float distancia = 0.5f;
    public float velocidad = 2f;

    public float tiempoAbierta = 1.5f;
    public float tiempoCerradaMin = 1.0f;

    private Vector3 posInicialIzq;
    private Vector3 posInicialDer;

    private bool abierta = false;
    private float tiempoCerrada = 0f;

    void Start()
    {
        posInicialIzq = izquierda.localPosition;
        posInicialDer = derecha.localPosition;

        StartCoroutine(Rutina());
    }

    void Update()
    {
       
        Vector3 targetIzq = abierta
            ? posInicialIzq + Vector3.right * distancia
            : posInicialIzq;

        Vector3 targetDer = abierta
            ? posInicialDer - Vector3.right * distancia
            : posInicialDer;

        izquierda.localPosition = Vector3.MoveTowards(
            izquierda.localPosition,
            targetIzq,
            velocidad * Time.deltaTime
        );

        derecha.localPosition = Vector3.MoveTowards(
            derecha.localPosition,
            targetDer,
            velocidad * Time.deltaTime
        );

        if (!abierta)
            tiempoCerrada += Time.deltaTime;
        else
            tiempoCerrada = 0f;
    }

    IEnumerator Rutina()
    {
        while (true)
        {
            abierta = true;
            yield return new WaitForSeconds(tiempoAbierta);

            abierta = false;

            yield return new WaitUntil(() =>
                Vector3.Distance(izquierda.localPosition, posInicialIzq) < 0.001f
            );

            yield return new WaitForSeconds(tiempoCerradaMin);
        }
    }

    public bool EstaCerrada()
    {
        return !abierta && tiempoCerrada >= tiempoCerradaMin;
    }

    public void RecibirDisparo()
    {
        if (EstaCerrada())
        {
            Debug.Log("ACIERTO");
            EliminarDiana();
        }
        else
        {
            Debug.Log("FALLO - diana abierta");
        }
    }

    public void EliminarDiana()
    {
        if (!EstaCerrada()) return;

        Destroy(gameObject);
    }
}