using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour {

    public float tumble;
    public Vector3 VelocityInitial;

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
        rigidbody.velocity = VelocityInitial;
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
