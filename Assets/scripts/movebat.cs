using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebat : MonoBehaviour
{
    Vector3 targetpos;
    Vector3 originalpos;
    [SerializeField] Transform pointer;
    [SerializeField] Transform ball;
    public float balldistance;
    bool move = false;
    public float xcoordinate;
    Vector3 to;
    [SerializeField] GameObject batrotate;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("the name of the gameobejct "+transform.gameObject.name);
        originalpos = transform.position;
        targetpos = transform.position;
        float degrees = 90;
   to = new Vector3(0, 0, 90);

        
    }

    // Update is called once per frame
    void Update()
    {
        xcoordinate = transform.position.x;
        //balldistance = Vector3.Distance(transform.position, ball.position);
        if (Input.GetMouseButtonDown(1))
        {
            move = true;
        }
        if(move)
        {
            targetpos.x = pointer.position.x;
            transform.position = Vector3.MoveTowards(transform.position, targetpos, Time.deltaTime * 10f);
            if (gameObject.name=="leftbat")
            {
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime * 10f);
            }
            else
            {
                Debug.Log("to "+to);
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, -to, Time.deltaTime * 10f);
            }

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = originalpos;
            move = false;
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "ball")
        {
            Vector3 randomdirection = new Vector3((Random.Range(0, 2) * 2 - 1) * 200f, (Random.Range(0, 2) * 2 - 1) * 200f, (Random.Range(0, 2) * 2 - 1) * 200f);
           
            collision.collider.attachedRigidbody.AddForce(randomdirection);
        }
    }



}
