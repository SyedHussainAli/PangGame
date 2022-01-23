using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTop : MonoBehaviour
{
    public float speed = 10;
    public float topBound = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if(transform.position.y>topBound)
        {
            Destroy(gameObject);
        }
            
    }
}
