using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lader : MonoBehaviour
{
    public PlayerController player;

    // Update is called once per frame
    //void Update()
    //{
    //    if (player.isClimbing)
    //    {
    //        player.GetComponentInParent<Rigidbody2D>().gravityScale = 0.01f;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().isClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().isClimbing = false;
        }
    }
}