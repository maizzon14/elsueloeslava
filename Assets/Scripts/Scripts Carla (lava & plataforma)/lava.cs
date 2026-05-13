using UnityEngine;
using UnityEngine.SceneManagement;

public class lava : MonoBehaviour
{
    public float velocidad = 2f;
    public GameObject botonTryAgain;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        botonTryAgain.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * velocidad * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diana") || other.gameObject.CompareTag("DianaMala"))
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("LOSE");
        }
    }
}
