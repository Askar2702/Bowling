using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void AccountHandler(int index);
    public event AccountHandler notify;
    
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform path;
    [SerializeField] private GameObject check;
    [SerializeField] private Vector3 finish;
    Vector3 target;
    private Vector3 vectorScale;
    private float MinScale = 0.4f;
    private GameObject _projectile;
    void Start()
    {
        Time.timeScale = 1;
        vectorScale = new Vector3(0.001f, 0.001f, 0.001f);
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _projectile = Instantiate(projectile, startPoint.position, Quaternion.identity);
        }
        if (Input.GetMouseButton(0))
        {
            _projectile.transform.localScale += vectorScale;
            transform.localScale -= vectorScale;
            path.localScale -= new Vector3(0.001f, 0, 0);
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            target = transform.position;
            target += transform.forward * 1;
            
        }
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 2f);

        if (check)
        {
            if (MinScale >= transform.localScale.x)
            {
                notify.Invoke(1);
                Time.timeScale = 0;
            }
        }
        else target = finish;
        if(5f > Vector3.Distance(finish, transform.position)) notify.Invoke(2);
        if (0.2f > Vector3.Distance(finish, transform.position)) notify.Invoke(0);
    }
}
