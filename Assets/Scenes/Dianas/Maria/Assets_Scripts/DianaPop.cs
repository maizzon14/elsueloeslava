using UnityEngine;
using System.Collections;

public class DianaPop : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject visual;
    public Collider col;

    [Header("Timing")]
    public float tiempoVisible = 2f;
    public float tiempoOculta = 1f;

    private bool destruida = false;

    void Start()
    {
        StartCoroutine(Rutina());
    }

    IEnumerator Rutina()
    {
        while (!destruida)
        {
            
            visual.SetActive(true);
            col.enabled = true;

            yield return new WaitForSeconds(tiempoVisible);

            
            visual.SetActive(false);
            col.enabled = false;

            yield return new WaitForSeconds(tiempoOculta);
        }
    }

    public void RecibirDisparo()
    {
        if (destruida) return;

        destruida = true;

        Debug.Log("DIANA ELIMINADA");

        Destroy(gameObject);
    }
}