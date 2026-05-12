using UnityEngine;

public class plataforma : MonoBehaviour
{
    public float velocidad = 2f;
    public bool activada = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if ( activada)
        {
            transform.Translate (Vector3.up * velocidad * Time.deltaTime);
        } 
    }
    public void Activar()
    {
        activada = true;
    }
}
