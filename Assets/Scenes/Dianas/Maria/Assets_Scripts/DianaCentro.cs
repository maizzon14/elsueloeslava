using UnityEngine;

public class DianaCentro : MonoBehaviour
{
    private DianaDinamica diana;

    void Start()
    {
        diana = GetComponentInParent<DianaDinamica>();
    }

    
    public void RecibirDisparo()
    {
        if (diana != null)
        {
            diana.RecibirDisparo();
        }
    }
}
