using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    public Material mm;
    public goal_a g;

    private void Awake()
    {
        mm = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        float b = (Vector3.Distance(g.transform.position, transform.position)/10) + g.t;

        while (b >= 5)
        {
            b -= 5;
        }

        for(int i = 0; i < g.c.Length-1; i++)
        {
            if (b >= i && b <= i + 1)
            {
                Color d = g.c[i + 1] - g.c[i];
                mm.color = g.c[i] + (d * (b - i));
            }
        }
    }
}
