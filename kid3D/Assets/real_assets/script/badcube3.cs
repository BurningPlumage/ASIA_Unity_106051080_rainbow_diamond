using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badcube3 : MonoBehaviour
{
    public GameObject cube;
    public GameObject target;
    private Vector3 originposition;

    bool go = false;
    bool back = false;

    private void Awake()
    {
        originposition = cube.transform.position;
    }

    private void Update()
    {
        if (go)
        {
            cube.transform.position = Vector3.MoveTowards(cube.transform.position, target.transform.position, 200 * Time.deltaTime);
        }

        if (back)
        {
            cube.transform.position = Vector3.MoveTowards(cube.transform.position, originposition, 70 * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "play" && !go && !back) 
        {
            Debug.Log("v");
            Invoke("startmove", 0.2f);
        }
    }

    void startmove()
    {
        go = true;
        Invoke("backmove", 0.5f);
    }
    void backmove()
    {
        go = false;
        back = true;
        Invoke("finshmove", 2);
    }
    void finshmove()
    {
        back = false;
    }

}
