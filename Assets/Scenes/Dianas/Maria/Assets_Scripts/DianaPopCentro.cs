using UnityEngine;

public class DianaPopCentro : MonoBehaviour
{
    private DianaPop diana;

    void Start()
    {
        diana = GetComponentInParent<DianaPop>();
    }

    public void RecibirDisparo()
    {
        if (diana != null)
        {
            diana.RecibirDisparo();
        }
    }
}
