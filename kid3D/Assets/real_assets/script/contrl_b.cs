using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contrl_b : MonoBehaviour
{
    public Animator ani;
    public Rigidbody rig;
    public GameObject movetar;

    public float speed1;
    public float speed2;

    bool walk = false;
    bool run = false;
    bool jump = false;
    bool is_ground;
    bool groundbug = true;

    bool canm = true;

    public GameObject cast_ground;
    
    public bool is_catch;
    public bool is_trigg;
    public itemset_a targ;
    public GameObject m_tar;

    public float tt;

    public GameObject revive;
    public camaset camar;

    private void Update()
    {

        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Body Animation Layer.hit03") || ani.GetCurrentAnimatorStateInfo(0).IsName("Body Animation Layer.toground"))
        {
            canm = false;
            rig.velocity = Vector3.zero;
            transform.Rotate(Vector3.zero);
        }
        else
        {
            canm = true;
        }


        Vector3 up = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.Space)&&canm&&is_ground)
        {
            ani.SetTrigger("jump");
            jump = true;
            up = new Vector3(0, 100, 0);
            groundbug = false;
            is_ground = false;
            Invoke("groub", 0.2f);
        }

        if (Input.GetKey(KeyCode.D) && canm) 
        {
            transform.Rotate(0, 80*Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A) && canm) 
        {
            transform.Rotate(0, -80*Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.W) && canm) 
        {
            walk = true;
            if (Input.GetKey(KeyCode.Q) && is_ground) 
            {
                run = true;
                rig.velocity = new Vector3(((movetar.transform.position - transform.position) * Time.deltaTime * speed2).x, rig.velocity.y, ((movetar.transform.position - transform.position) * Time.deltaTime * speed2).z);
            }
            else
            {
                run = false;
                rig.velocity = new Vector3(((movetar.transform.position - transform.position) * Time.deltaTime * speed1).x, rig.velocity.y, ((movetar.transform.position - transform.position) * Time.deltaTime * speed1).z);
            }
        }
        else
        {
            walk = false;
            run = false;
        }
        rig.velocity += up;


        if (Input.GetKeyDown(KeyCode.Mouse0) && !jump && canm && is_ground)  
        {
            canm = false;
            ani.SetTrigger("att");
            if ( !is_catch)
            {
                Invoke("at", tt);
            }
            else if (is_catch)
            {
                Invoke("catchdown", 0.4f);
            }
        }

        ani.SetBool("walk", walk);
        ani.SetBool("run", run);
        ani.SetBool("isground", is_ground);

        
    }

    void at()
    {
        if (is_trigg)
        {
            is_catch = true;
            targ.rig.useGravity = false;
            targ.coli.enabled = false;
            targ.target = m_tar;
            is_trigg = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(groundbug) is_ground = true;
    }
    private void OnTriggerExit(Collider other)
    {
        is_ground = false;
        jump = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "dead line")
        {
            Debug.Log("v");
            transform.position = revive.transform.position;
            transform.rotation = revive.transform.rotation;

            camar.transform.position = camar.target.transform.position;
            camar.transform.rotation = revive.transform.rotation;
        }
    }


    void groub()
    {
        groundbug = true;
    }

    void catchdown()
    {
        is_catch = false;
        targ.rig.useGravity = true;
        targ.coli.enabled = true;
        targ.target = null;
        targ = null;
    }
}
