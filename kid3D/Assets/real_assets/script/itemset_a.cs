using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemset_a : MonoBehaviour
{
    public bool cancatch;
    public Rigidbody rig;

    public Collider coli;

    public GameObject target;

    public Vector3 originposition;

    private void Awake()
    {
        cancatch = true;
        rig.useGravity = true;
        rig.isKinematic = false;
        coli.enabled = true;

        originposition = transform.position;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.transform.position;
            transform.rotation = target.transform.rotation;
        }
    }


    public void iitem()
    {
        target = null;

        cancatch = false;
        rig.useGravity = false;
        rig.isKinematic = true;
        coli.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "dead line")
        {
            transform.position = originposition;
        }
    }
}
