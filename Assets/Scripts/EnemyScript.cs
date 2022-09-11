using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] public float _enemySpeed = 1f;
    [SerializeField] public int _enemyHealth = 1;
    int _enemyOriginalHealth = 0;
    
    //[SerializeField] GameObject PowerUp1, PowerUp2, PowerUp3;
    [SerializeField] List<GameObject> PowerUps = new List<GameObject> {};
    int randomPowerUp;
    float rand;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,15);
        _enemyOriginalHealth += _enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -(Time.deltaTime * _enemySpeed),0);

        if(_enemyHealth <=0)
            {
                
            if(PowerUps.Count != 0)
            {
                rand = Random.Range(0,10);
                Debug.Log(rand);
                if(rand > 8)
                {
                randomPowerUp = Random.Range(0, PowerUps.Count);
                Instantiate(PowerUps[randomPowerUp], this.transform.position, Quaternion.identity);
                };
            }
           
            GameController.Instance.addScore(10 * (_enemyOriginalHealth));
            Destroy(gameObject);
            }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider);
        if(collider.gameObject.CompareTag("Player"))
        {
            _enemyHealth -= 1;
        }
        if(collider.gameObject.CompareTag("PlayerLaser"))
        {
            _enemyHealth -= collider.GetComponent<LaserScript>()._laserDamage;
            
            Destroy(collider.gameObject);
        }
        
    }
}
