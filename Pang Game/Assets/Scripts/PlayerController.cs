using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed=10;
    public float horizontalInput;
    public float xRange = 10.0f;

    public GameObject bulletPF;
   

    public GameObject smallPF;


    private int lives = 3;
    public int scores = 0;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) 
        {
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Launch projectile from player
                Vector3 bulletPosttion = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                Instantiate(bulletPF, bulletPosttion, bulletPF.transform.rotation);

            }
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BigBall"))
        {
            if (lives > 0) 
            {
                lives--;
                Destroy(collision.gameObject);
                spawnBalls();
            }
            else 
            {
                Debug.Log("Score is:"+scores);
                Debug.Log("Game Over");
                gameOver = true;

            } 
        }
        if (collision.gameObject.CompareTag("SmallBall"))
        {
            if (lives > 0)
            {
                lives--;
                Destroy(collision.gameObject);
            }
            else
            {
                Debug.Log("Score is:" + scores);
                Debug.Log("Game Over");
                gameOver = true;

            }
        }
    }
    void spawnBalls()
    {
        Vector3 spawnLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject ballL = Instantiate(smallPF, spawnLocation, smallPF.transform.rotation);
        ballL.GetComponent<Rigidbody>().AddForce(Vector3.left * 3, ForceMode.Impulse);
        GameObject ballR = Instantiate(smallPF, spawnLocation, smallPF.transform.rotation);
        ballR.GetComponent<Rigidbody>().AddForce(Vector3.right * 3, ForceMode.Impulse);
        
    }
}
