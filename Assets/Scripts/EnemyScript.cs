using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float _enemySpeed = 1f;
    [SerializeField] int _enemyHealth = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,15);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -(Time.deltaTime * _enemySpeed),0);

        if(_enemyHealth <=0)
            {
            Destroy(gameObject);
            
            GameController.Instance.addScore(10);
            }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider);
        if(collider.gameObject.name == "player_Ship")
        {
            GameController.Instance.startGameOver();
        }
        Destroy(collider.gameObject);
        _enemyHealth -= 1;
    }
}
