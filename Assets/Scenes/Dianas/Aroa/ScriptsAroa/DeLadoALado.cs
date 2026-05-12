using UnityEngine;

public class DeLadoALado : MonoBehaviour
{
    public float moveDistance = 3f;   // hasta dnde se mueve desde el punto inicial
    public float speed = 4f;       

    private Vector3 startPos;

    void Start()
    {
        // posicion inicial para que funcione en cualquier sitio
        startPos = transform.position;
    }

    void Update()
    {
        // Movimiento tipo ping pong entre posicion x e y
        float offset = Mathf.PingPong(Time.time * speed, moveDistance * 2) - moveDistance;

        // solo en horizontal
        transform.position = new Vector3(startPos.x + offset, startPos.y, startPos.z);
    }

}
