
    using UnityEngine;

    public class Background : MonoBehaviour
    {

   
        [SerializeField] Vector3 startPos;
        [SerializeField] float repeatWitdh;
        // Start is called before the first frame update
        void Start()
        {
            startPos = transform.position;
            repeatWitdh = GetComponent<BoxCollider>().size.x / 2;
        }

        // Update is called once per frame
        void Update()
        {
            if(transform.position.x >  startPos.x + 3)
            {

                transform.position = startPos;
            }
        }
    }
