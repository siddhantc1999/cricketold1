using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class touchpoint : MonoBehaviour
{
    Ray myray;
    public Vector3 mousescreenposition;
    public Vector3 mouseworldposition;
    public Vector3 hitposition;
    [SerializeField] GameObject pointer;
    LayerMask layermask;
    public Rigidbody ball;
    public Vector3 initialpos;
    //public float zmultiplier;
    //public float xmultiplier;
    //public float ymultiplier;
    public float multiplier;
    public Vector3 differencevector;
    //public GameObject xminzmin;
    //public GameObject xmaxzmax;
    public float xmin;
    public float xmax;
    public float zmin;
    public float zmax;
    float xcoordinate;
    float zcoordinate;
    public Vector3 balldirection;
    battingdirection mybattingdirection;
    public Vector3 testvector;
   
    //public List<boundaryscript> myboundaryscripts;

    // Start is called before the first frame update
    [Obsolete]
    void Start()
    {
        
        
        ball.isKinematic = true;
        mybattingdirection = FindObjectOfType<battingdirection>();
        layermask = LayerMask.GetMask("ballpitch");
        initialpos = FindObjectOfType<balldirection>().initialpos;
        
    }

    // Update is called once per frame
    [Obsolete]
    void Update()
    {
        

        xmin = mybattingdirection.xmin;
        zmin= mybattingdirection.zmin;
        xmax = mybattingdirection.xmax;
        zmax = mybattingdirection.zmax;
        initialpos = ball.transform.position;


        if (Input.GetMouseButtonDown(1) && ball.GetComponent<Rigidbody>().velocity==Vector3.zero)
        {
            mousescreenposition = Input.mousePosition;
            mouseworldposition = Camera.main.ScreenToWorldPoint(new Vector3(mousescreenposition.x, mousescreenposition.y, Camera.main.nearClipPlane));
            myray = Camera.main.ScreenPointToRay(Input.mousePosition);
           
            //Debug.DrawRay(myray.origin, myray.direction * 1000f, Color.red);
            RaycastHit myraycasthit;
 
            if (Physics.Raycast(myray, out myraycasthit,Mathf.Infinity,layermask))
                {
                hitposition = myraycasthit.point;
                xcoordinate = Mathf.Clamp(hitposition.x, xmin, xmax);
                zcoordinate = Mathf.Clamp(hitposition.z, zmin, zmax);
                Vector3 finalhitposition = new Vector3(xcoordinate, 0.01f, zcoordinate);
                pointer.transform.position = finalhitposition;
                balldirection = pointer.transform.position;
                ball.isKinematic = false;
                //Debug.Log("the initiual pos "+initialpos);
                differencevector = (balldirection - initialpos).normalized;
                ball.velocity = Vector3.zero;
                ball.AddForce(differencevector* multiplier);
               
            }

            
        }
       
    }

   
}
