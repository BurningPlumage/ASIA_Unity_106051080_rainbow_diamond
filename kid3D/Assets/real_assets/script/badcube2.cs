using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badcube2 : MonoBehaviour
{
    private float t;
    public bool act;
    private MeshRenderer mr;
    private Collider co;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        co = GetComponent<Collider>();
    }

    private void Update()
    {
        t += Time.deltaTime;
        if (t >= 3)
        {
            t -= 3;
            if (act)
            {
                act = false;
                mr.enabled = false;
                co.enabled = false;
            }
            else
            {
                act = true;
                mr.enabled = true;
                co.enabled = true;
            }
        }
    }
}
