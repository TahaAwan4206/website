using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float bulletSpeed = 15f;
    public Rigidbody2D rb;
    public GameObject impacteffect;
    public Vector2 moveDirection;
    public int damageAmount = 1;
   
    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveDirection * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealthController>().DamageEnemy(damageAmount);
        }

        if(impacteffect!= null)
        {
            Instantiate(impacteffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
