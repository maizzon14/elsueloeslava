using UnityEngine;

public class lava : MonoBehaviour
{
    public float velocidad = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * velocidad * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Diana") || other.gameObject.CompareTag("DianaMala"))
        {
            Destroy(other.gameObject);
        }
    }
}
