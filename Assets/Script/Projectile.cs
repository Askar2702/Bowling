using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ParticleSystem Boom;
    private Rigidbody rb;
    private Color _color;
    private float radius;
    private float speed = 70f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        _color = GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = new Vector3(0f, 0f,  10f * speed * Time.deltaTime);
            radius = Radius(transform.localScale.x);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Obstacle>())
        { 
            for(int i = 0; i < GameManager.gameManager.obstacles.Count; i++)
            {
                if(radius > Vector3.Distance(GameManager.gameManager.obstacles[i].transform.position, transform.position))
                {

                    Instantiate(Boom, transform.position, Quaternion.identity);
                    GameManager.gameManager.obstacles[i].GetComponent<MeshRenderer>().material.color = _color;
                    GameManager.gameManager.obstacles[i].StartCoroutine("destroySelf");
                    Destroy(this.gameObject);
                }
            }
        }
    }
    private float Radius(float scale)
    {
        return scale / 0.3f;
    }
}
