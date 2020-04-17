using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    /* public float timeToRevivePlayer;
     private float timeRevivalCounter;

     private bool playerReviving;
     private GameObject thePlayer;
     */
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject
                .GetComponent<HealthManager>()
                .DamageCharacter(this.damage);
        }
    }

    private void Update()
    {
        /*if (playerReviving)
        {
            timeRevivalCounter -= Time.deltaTime;
            if (timeRevivalCounter < 0)
            {
                playerReviving = false;
                thePlayer.SetActive(true);
            }
        }
        */
    }
}
