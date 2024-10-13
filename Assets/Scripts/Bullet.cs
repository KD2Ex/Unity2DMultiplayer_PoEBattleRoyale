using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private void OnEnable()
    {
        rb.velocity = transform.right * 30f;
        StartCoroutine(Timer(1.5f));
    }

    private void OnDisable()
    {
        rb.transform.position = Vector3.zero;
    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        //transform.right = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) return;
        ObjectPoolManager.ReturnToPool(gameObject);
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        ObjectPoolManager.ReturnToPool(gameObject);
    }
}