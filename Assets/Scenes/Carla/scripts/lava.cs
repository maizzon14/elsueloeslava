using UnityEngine;

public class lava : MonoBehaviour
{
    public float velocidadEscala = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 escala = transform.localScale;
        escala.y += velocidadEscala * Time.deltaTime;
        transform.localScale = escala;

        
    }
}
