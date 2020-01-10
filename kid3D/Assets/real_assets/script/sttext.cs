using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sttext : MonoBehaviour
{
    [TextArea(3, 5)]
    public string s;

    public Text t;

    public bool b;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "play")
        {
            t.text = s;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "play"&&b)
        {
            t.text = "";
        }
    }
}
