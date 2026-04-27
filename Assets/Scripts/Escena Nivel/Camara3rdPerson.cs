using UnityEngine;

public class Camara3rdPerson : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 2f, -4f);
    public Vector3 lookOffset = new Vector3(0f, 1.5f, 0f);

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = target.position + target.rotation * offset;
        transform.LookAt(target.position + lookOffset);
    }
}
