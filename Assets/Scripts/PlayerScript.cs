using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject _laserPrefab;

    [SerializeField] int _playerHealth = 4;
    [SerializeField] int _playerLaserDamage = 1;
    [SerializeField] int _playerLaserSpeed = 5;

    bool _FireButtonHeld = true;
    [SerializeField] float _playerFireRate = .5f;
    [SerializeField] bool _playerCanFire = true;


    [SerializeField] bool _hasTripleShot = false;

    [SerializeField] GameObject LaserPoint1;
    [SerializeField] GameObject LaserPoint2;
    [SerializeField] GameObject LaserPoint3;

    [SerializeField] GameObject Health1;
    [SerializeField] GameObject Health2;
    [SerializeField] GameObject Health3;

    [SerializeField] Sprite RedLaser;
    [SerializeField] Sprite BlueLaser;

    void Start()
    {
        Debug.Log("Spaceship Spawned");
        UpdateHealth();
        _laserPrefab.GetComponent<SpriteRenderer>().sprite = BlueLaser;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _FireButtonHeld = true;
        };

        if(Input.GetButtonUp("Fire1"))
        {
            _FireButtonHeld = false;
        };

        if(_FireButtonHeld && _playerCanFire)
        {
            StartCoroutine(FireShot());
        }

        if(_playerHealth <= 0)
        {
            GameController.Instance.startGameOver();
            Destroy(this.gameObject);
        };


        Vector3 convertPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(convertPos.x, transform.position.y, 0);
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);

        if(collider.gameObject.CompareTag("Enemy"))
        {
            _playerHealth -= 1;
            UpdateHealth();
            Debug.Log("enemy hit");
        }
        else if(collider.gameObject.CompareTag("TripleShot"))
        {
            StartCoroutine(TripleShot());
        }
        else if(collider.gameObject.CompareTag("DoubleDamage"))
        {
            StartCoroutine(DoubleDamage());
        }
        else if(collider.gameObject.CompareTag("Health"))
        {
            if(_playerHealth < 4)
            {
                _playerHealth+=1;
                UpdateHealth();
            }
        }
    }

    IEnumerator FireShot()
    {
        _playerCanFire = false;
        _laserPrefab.GetComponent<LaserScript>()._laserDamage = _playerLaserDamage;
        _laserPrefab.GetComponent<LaserScript>()._laserSpeed = _playerLaserSpeed;
        Instantiate(_laserPrefab, LaserPoint1.transform.position, Quaternion.identity);
        if(_hasTripleShot)
        {
            Instantiate(_laserPrefab, LaserPoint2.transform.position , Quaternion.identity);
            Instantiate(_laserPrefab, LaserPoint3.transform.position , Quaternion.identity);
        }
        yield return new WaitForSeconds(_playerFireRate);
        _playerCanFire = true;
        
    }

    IEnumerator TripleShot()
    {
        _hasTripleShot = true;
        yield return new WaitForSeconds(4);
        _hasTripleShot = false;
    }
    
    IEnumerator DoubleDamage()
    {
        _playerLaserDamage = _playerLaserDamage * 2;
        _playerLaserSpeed= _playerLaserSpeed * 2;
        _laserPrefab.GetComponent<SpriteRenderer>().sprite = RedLaser;
        yield return new WaitForSeconds(5);
        _playerLaserDamage = _playerLaserDamage / 2;
        _playerLaserSpeed= _playerLaserSpeed / 2;
        _laserPrefab.GetComponent<SpriteRenderer>().sprite = BlueLaser;
    }

    //Wow this is a terrible way to do this! Oh well!
    void UpdateHealth()
    {
        if(_playerHealth == 4)
        {
            Health1.SetActive(true);
            Health2.SetActive(true);
            Health3.SetActive(true);
        }
        else if(_playerHealth == 3)
        {
            Health1.SetActive(true);
            Health2.SetActive(true);
            Health3.SetActive(false);
        }
        else if(_playerHealth == 2)
        {
            Health1.SetActive(true);
            Health2.SetActive(false);
            Health3.SetActive(false);
        }
        else 
        {
            Health1.SetActive(false);
            Health2.SetActive(false);
            Health3.SetActive(false);
        }
       
    }
}
