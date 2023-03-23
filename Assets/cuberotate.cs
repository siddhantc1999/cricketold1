using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuberotate : MonoBehaviour
{
    public Quaternion startpos;
    public Quaternion endpos;
    public float timer=0;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.rotation;
        endpos = Quaternion.Euler(0f,0f,30f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 1)
        {
            transform.rotation=Quaternion.Slerp(startpos, endpos, Time.deltaTime);
            timer += Time.deltaTime;
        }
    }
}
