using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal_a : MonoBehaviour
{
    public int n = 0;

    public float t = 0;
    public Color[] c;

    public GameObject wt;

    public contrl_b player;
    public camaset cmara;
    public GameObject winpoint;

    public badcub1 bc;
    public cube cb;

    bool b = false;

    private void Update()
    {
        t += Time.deltaTime * 0.5f;
        if (t > 5)
        {
            t -= 5;
        }

        if (b)
        {
            player.transform.Rotate(0, 30 * Time.deltaTime, 0);
            player.transform.localPosition = new Vector3(0, 0.5f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item")
        {
            other.transform.GetComponent<itemset_a>().iitem();
            other.transform.parent = transform;
            n++;
            if (n >= 5)
            {
                bc.enabled = true;
                cb.mm.color = Color.white;
                cb.enabled = false;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "play" && bc.move && n >= 5) 
        {
            player.ani.Play("winpose");
            player.enabled = false;
            Destroy(player.rig);
            player.transform.parent = transform;
            player.transform.localPosition = new Vector3(0, 0.5f, 0);

            cmara.target = winpoint;
            cmara.rot = player.gameObject; ;
            cmara.transform.position = winpoint.transform.position;
            cmara.transform.rotation = Quaternion.Euler(0, player.transform.rotation.eulerAngles.y + 180, 0);

            cb.enabled = true;

            b = true;
        }
    }
}
