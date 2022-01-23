using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollusionEnter : MonoBehaviour
{
    private Rigidbody objectRB;
    private float upForce = 10;
    private float sideForce = 5;
    public GameObject smallPF;
    private PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        objectRB = GetComponent<Rigidbody>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
      if(!playerControllerScript.gameOver)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                objectRB.AddForce(Vector3.up * upForce, ForceMode.Impulse);
            }
            if (collision.gameObject.CompareTag("RightWall"))
            {
                objectRB.AddForce(Vector3.left * sideForce, ForceMode.Impulse);
            }
            if (collision.gameObject.CompareTag("LeftWall"))
            {
                objectRB.AddForce(Vector3.right * sideForce, ForceMode.Impulse);
            }
            if (collision.gameObject.CompareTag("BigBall") && this.gameObject.CompareTag("Bullet"))
            {
                Destroy(gameObject);
                SpawnSmallBalls();
                Destroy(collision.gameObject);
                playerControllerScript.scores++;
            }
            if (collision.gameObject.CompareTag("SmallBall") && this.gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                playerControllerScript.scores++;
            }
        }


    }
    void SpawnSmallBalls()
    {
        Vector3 spawnLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject ballL = Instantiate(smallPF, spawnLocation, smallPF.transform.rotation);
        ballL.GetComponent<Rigidbody>().AddForce(Vector3.left * 3, ForceMode.Impulse);
        GameObject ballR = Instantiate(smallPF, spawnLocation, smallPF.transform.rotation);
        ballR.GetComponent<Rigidbody>().AddForce(Vector3.right * 3, ForceMode.Impulse);
    }
}
