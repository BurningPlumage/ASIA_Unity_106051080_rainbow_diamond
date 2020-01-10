using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemset_a : MonoBehaviour
{
    public bool cancatch;
    public Rigidbody rig;

    public Collider coli;

    public GameObject target;

    private void Awake()
    {
        cancatch = true;
        rig.useGravity = true;
        rig.isKinematic = false;
        coli.enabled = true;
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
}
