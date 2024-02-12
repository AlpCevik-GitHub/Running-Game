    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BackgroundRight : MonoBehaviour
    {
        [SerializeField] Vector3 startPos;
        [SerializeField] float repeatWitdh;
        // Start is called before the first frame update
        void Start()
        {
            startPos = transform.position;
            repeatWitdh = GetComponent<BoxCollider>().size.x / 4.3f;
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.x < startPos.x - 5.49)
            {

                transform.position = startPos;
            }
        }
    }
