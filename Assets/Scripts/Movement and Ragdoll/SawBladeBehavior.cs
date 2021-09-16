using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladeBehavior : MonoBehaviour
{
    [Tooltip("This will be the lower value border")]
    [SerializeField]
    private GameObject _border1;

    [Tooltip("This is the greater value border")]
    [SerializeField]
    private GameObject _border2;

    public float speed;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= _border1.transform.position.x)
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
  
        }
        else if(transform.position.x <= _border2.transform.position.x)
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
           
        }
    }
}
