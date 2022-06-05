using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -5;

    public ParticleSystem explosionPS;
    private Rigidbody targetRb;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        SpawnTarget();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnTarget()
    {
        targetRb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
    }

    //private void OnMouseDown()
    //{
    //    DestroyTarget();
    //}

    private void OnTriggerEnter(Collider other)
    {
        gameManager.UpdateScore(-pointValue);
        if (!gameObject.CompareTag("Bad") && gameManager.isGameActive)
        {
            //gameManager.GameOver();
            gameManager.UpdateLives(-1);
        }
        Destroy(gameObject);
    }

    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionPS, transform.position, explosionPS.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }
}
