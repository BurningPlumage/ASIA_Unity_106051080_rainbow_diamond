using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badcub1 : MonoBehaviour
{
    public GameObject target;
    private Vector3 originpoistin;

    public bool move;

    private void Awake()
    {
        originpoistin = transform.position;
    }

    private void Update()
    {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 100 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "play")
        {
            collision.transform.parent = transform;
            Invoke("startmove", 1.5f);
        }
    }

    void startmove()
    {
        move = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "play")
        {
            collision.transform.parent = null;
            Invoke("finishmove", 1.5f);
        }
    }
    void finishmove()
    {
        move = false;
        transform.position = originpoistin;
    }
}
