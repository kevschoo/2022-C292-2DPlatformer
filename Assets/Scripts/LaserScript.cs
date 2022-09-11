using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float _laserSpeed = 1f;
    public int _laserDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
       Destroy(gameObject,5);
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
