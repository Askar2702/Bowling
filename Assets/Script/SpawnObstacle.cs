using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private int count;
    private GameObject _obstacle;
    private Vector3 spawn;
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            spawn = new Vector3(Random.Range(-4f, 4f), Random.Range(0f, 0.5f), Random.Range(-1.5f, 8f));
            _obstacle = Instantiate(obstacle, spawn, Quaternion.identity);
            _obstacle.transform.parent = transform;
            _obstacle.transform.name += i;
        }
    }

    
}
