using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player__ : MonoBehaviour
{
    private Camera mainCamera => Camera.main;

    [SerializeField] private GameObject bullet1;
    [SerializeField] private GameObject bullet2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var dir = (mousePos - transform.position).normalized;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        
        if (Input.GetMouseButton(0))
        {
            ObjectPoolManager.SpawnObject(bullet1, transform.position, transform.rotation);
            //Instantiate(bullet1, transform.position, transform.rotation);
        }

        if (Input.GetMouseButton(1))
        {
            ObjectPoolManager.SpawnObject(bullet2, transform.position, transform.rotation);
            //Instantiate(bullet2, transform.position, transform.rotation);
        }
    }
}
