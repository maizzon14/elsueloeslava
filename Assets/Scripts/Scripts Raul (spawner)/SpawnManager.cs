using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform player;            
    public GameObject[] prefabs;       

    public int maxDianas = 5;         
    public float radio = 3f;           
    public float alturaY = 1f;       
    public float minDistancia = 1.5f;
    Vector3 pos;

    List<GameObject> targets = new List<GameObject>();

    void Awake()
    {
        
        for (int i = 0; i < maxDianas; i++)
            Spawn();
    }

    void Update()
    {

        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] == null)
            {
                targets.RemoveAt(i);
                i--;
            }
        }

        if (targets.Count < maxDianas)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        
        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
        int intentos = 0;
        bool posicionMala = true;

        while (posicionMala && intentos < 10)
        {
            Vector2 randomCircle = Random.insideUnitCircle * radio;

            pos = player.position + new Vector3(randomCircle.x,Random.Range(-alturaY, alturaY),randomCircle.y);

            posicionMala = MuyCerca(pos);
            intentos++;
        }

       
        GameObject newTarget = Instantiate(prefab, pos, Quaternion.identity, transform);
        targets.Add(newTarget);
        newTarget.transform.LookAt(player);
    }

    bool MuyCerca(Vector3 pos)
    {
        foreach (GameObject t in targets)
        {
            if (t == null) continue;
            if (Vector3.Distance(pos, t.transform.position) < minDistancia)
                return true;
        }
        return false;
    }
}
