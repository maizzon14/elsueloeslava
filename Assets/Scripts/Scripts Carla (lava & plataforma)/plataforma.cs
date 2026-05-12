using UnityEngine;

public class plataforma : MonoBehaviour
{
    public BalaData balaData;
    public float velocidad = 2f;

    private void Update()
    {
        SubirPlataforma(balaData.cantidadPlataforma);
    }

    void SubirPlataforma(float cantidad)
    {
        if(balaData.activarPlataforma)
        {
            transform.position += (Vector3.up * cantidad);
            balaData.activarPlataforma = false;
        }
    }
}
