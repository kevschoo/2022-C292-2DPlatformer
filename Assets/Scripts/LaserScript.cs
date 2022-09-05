using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] float _laserSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
       Destroy(gameObject,10);
    }

    // Update is called once per frame
    void Update()
    {


        transform.position += new Vector3(0, Time.deltaTime * _laserSpeed,0);


    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
    }
}
