using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject _laserPrefab;

    [SerializeField] int _playerHealth = 1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spaceship Spawned");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            };
        Vector3 convertPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(convertPos.x, transform.position.y, 0);
        
       
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider);
        Destroy(collider.gameObject);
        _playerHealth -= 1;
    }
}
