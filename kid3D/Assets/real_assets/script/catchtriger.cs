using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchtriger : MonoBehaviour
{
    public contrl_b contrl;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "item" && !contrl.is_catch)
        {
            contrl.is_trigg = true;
            contrl.targ = other.transform.GetComponent<itemset_a>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "item")
        {
            contrl.is_trigg = false;
        }
    }
}
