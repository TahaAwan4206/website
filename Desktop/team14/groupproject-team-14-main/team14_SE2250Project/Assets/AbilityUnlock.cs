using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AbilityUnlock : MonoBehaviour
{
    public bool unlockDoubleJump;
    public bool unlockDashing;
    public bool unlockBall;
    public bool unlockBomb;
    public GameObject pickupEffect;
    public string unlockedMessage;
    public TMP_Text unlockText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            AbilityTracker player = collision.GetComponentInParent<AbilityTracker>();
            if (unlockDoubleJump)
            {
                player.DoubleJump = true;
            }
            if (unlockDashing)
            {
                player.Dash = true;
            }
            if (unlockBall)
            {
                player.Ball = true;
            }
            if (unlockBomb)
            {
                player.DropBomb = true;
            }

            Instantiate(pickupEffect, transform.position, transform.rotation);
            unlockText.transform.parent.SetParent(null);
            unlockText.transform.parent.position = transform.position;
            unlockText.text = unlockedMessage;
            unlockText.gameObject.SetActive(true);
            Destroy(unlockText.transform.parent.gameObject, 5f);

            Destroy(gameObject);
        }


    }

}
