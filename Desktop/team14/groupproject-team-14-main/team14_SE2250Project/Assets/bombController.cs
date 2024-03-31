using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombController : MonoBehaviour
{

    public float explodeTime = 0.8f;
    public GameObject explosion;
    public float blastRange;
    public LayerMask destructableLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        explodeTime -= Time.deltaTime;
        if (explodeTime <= 0)
        {
            if(explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            Destroy(gameObject);

            Collider2D[] destructableObjects = Physics2D.OverlapCircleAll(transform.position, blastRange, destructableLayer);
            if(destructableObjects.Length > 0)
            {
                foreach(Collider2D element in destructableObjects)
                {
                    Destroy(element.gameObject);
                }
            }
        }
    }
}
