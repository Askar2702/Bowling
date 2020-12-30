using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    [System.Obsolete]
    void Start()
    {
        Destroy(this.gameObject, 1.5f);
    }

    
}
