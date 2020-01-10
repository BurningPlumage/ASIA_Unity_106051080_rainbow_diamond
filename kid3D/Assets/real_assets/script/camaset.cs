using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaset : MonoBehaviour
{
    public GameObject target;
    public GameObject rot;

    private void LateUpdate()
    {
        Vector3 v = Vector3.Lerp(target.transform.position, transform.position, 1);
        Vector3 vv = (target.transform.position - v) * Time.deltaTime * 2;
        transform.position += vv;

        Vector3 targetDir = rot.transform.position - transform.position;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 0.1f, 0.0F);

        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
