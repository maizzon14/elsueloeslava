using UnityEngine;

public class Petit : MonoBehaviour

{
 
    public float minPetit = 0.3f;   
    public float maxGrandet = 1f;    
    public float speed = 1f;       

    private Vector3 originalScale;

    void Start()
    {
        //  para que funcione en cualquier tamaño
        originalScale = transform.localScale;
    }

    void Update()
    {
        //valor entre 0 y 1 que los recorre constantemente
        float t = Mathf.PingPong(Time.time * speed, 1f);

        // cuando t-0 scale es minPetit    cuando t-1 scale es maxGrandet
        float scale = Mathf.Lerp(minPetit, maxGrandet, t);

        // nuevo tamaño
        transform.localScale = originalScale * scale;
    }
}
