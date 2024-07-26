using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("Player")) // letar efter om player krockar med föremålet
        {
            Player player = collision.gameObject.GetComponent<Player>(); // hämtar referens för player
            player.TakeDamge(100); //Skadar player
        }
    }
}
