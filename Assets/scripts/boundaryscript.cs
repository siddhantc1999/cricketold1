using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaryscript : MonoBehaviour
{
    public Vector3 centre;
    public GameObject xmaxzmax;
    public GameObject xminzmin;
    public float localxmin;
    public float localxmax;
    public float localzmin;
    public float localzmax;
    [SerializeField] GameObject ball;
    // Start is called before the first frame update
    private void Awake()
    {
        localxmax = xmaxzmax.transform.position.x;
        localzmax = xmaxzmax.transform.position.z;
        localxmin = xminzmin.transform.position.x;
        localzmin = xminzmin.transform.position.z;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(ball.transform.position);
        //centre=transform.GetComponent<BoxCollider>().bounds.;
        
    }
}
