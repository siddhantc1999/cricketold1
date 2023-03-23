using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class battingdirection : MonoBehaviour
{
    public List<boundaryscript> myboundaryscripts;
    public float xmin;
    public float xmax;
    public float zmin;
    public float zmax;
    [SerializeField] Transform ball;
    float timer = 0;
    public float balldistance;
    Vector3 targetpos;
    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        myboundaryscripts = FindObjectsOfType<boundaryscript>().ToList();
        myboundaryscripts[0].gameObject.active = false;
        targetpos = transform.position;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {

        //balldistance = Vector3.Distance(transform.position, ball.position);
        //if (Vector3.Distance(transform.position,ball.position)<=160)
        //{ 
        //if (transform.position != ball.transform.position)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, new Vector3(ball.position.x, ball.position.y, transform.position.z), timer);
        //    timer += Time.deltaTime;
        //}
        //}

        //balldistance = Vector3.Distance(transform.position, ball.position);
       

        foreach (boundaryscript boundaryscript in myboundaryscripts)
        {
            if (boundaryscript.gameObject.active == true)
            {
                boundaryscript.gameObject.active = true;
                xmin = boundaryscript.localxmin;
                zmin = boundaryscript.localzmin;
                xmax = boundaryscript.localxmax;
                zmax = boundaryscript.localzmax;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            foreach (boundaryscript thisboundaryscript in myboundaryscripts)
            {
                if (thisboundaryscript.gameObject.active == false)
                {
                    thisboundaryscript.gameObject.active = true;
                    xmin = thisboundaryscript.localxmin;
                    zmin = thisboundaryscript.localzmin;
                    xmax = thisboundaryscript.localxmax;
                    zmax = thisboundaryscript.localzmax;
                }
                else
                {
                    thisboundaryscript.gameObject.active = false;
                }


            }
        }




    }
}
