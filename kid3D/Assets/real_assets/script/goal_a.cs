using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal_a : MonoBehaviour
{
    private int n = 0;

    public float t = 0;
    public Color[] c;

    public GameObject wt;

    private void Update()
    {
        t += Time.deltaTime * 0.5f;
        if (t > 5)
        {
            t -= 5;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item")
        {
            other.transform.GetComponent<itemset_a>().iitem();
            n++;
            if (n >= 5)
            {
                wt.SetActive(true);
            }
        }
    }
}
