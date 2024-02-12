using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPickUpOutOfBounds : MonoBehaviour
{
    private float playerBackBound = 41.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > playerBackBound)
        {
            Destroy(gameObject);
        }

    }
}
