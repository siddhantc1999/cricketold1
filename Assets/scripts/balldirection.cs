using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balldirection : MonoBehaviour
{
    public Transform ballleftpos;
    public Transform ballrighttpos;
    public Vector3 initialpos;
    // Start is called before the first frame update
    void Start()
    {
        
        transform.position = ballleftpos.position;
        initialpos = ballleftpos.position;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(transform.GetComponent<Rigidbody>().velocity);
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = ballrighttpos.position;
            initialpos = ballrighttpos.position;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = ballleftpos.position;
            initialpos = ballleftpos.position;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            transform.position = initialpos;
            transform.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
