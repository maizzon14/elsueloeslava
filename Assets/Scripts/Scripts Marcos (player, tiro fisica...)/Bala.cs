using UnityEngine;

public class Bala : MonoBehaviour
{
    public BalaData balaData;
    void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Diana"))
        {
            print("me han dado!!");
            balaData.activarPlataforma = true;
            balaData.cantidadPlataforma = 3f;
            
            DianaMorir dianaMorir = collision.gameObject.GetComponentInParent<DianaMorir>();

            if (dianaMorir != null)
                dianaMorir.Morir();
        }
        else if(collision.gameObject.CompareTag("DianaMala"))
        {
            print("me han dado!!");
            balaData.activarPlataforma = true;
            balaData.cantidadPlataforma = -3f;

            DianaMorir dianaMorir = collision.gameObject.GetComponentInParent<DianaMorir>();

            if (dianaMorir != null)
                dianaMorir.Morir();
        }

            Destroy(gameObject);
    }
}
