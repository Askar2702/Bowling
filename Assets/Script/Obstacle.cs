using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] private ParticleSystem Boom;
    private void Start()
    {
        GameManager.gameManager.AddListObstacles(this);
    }
    
    public IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(Boom, transform.position, Quaternion.identity);
        GameManager.gameManager.DeleteItemObstacles(this);
        Destroy(this.gameObject);
    }
}
