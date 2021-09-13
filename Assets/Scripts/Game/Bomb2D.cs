using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb2D : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ballon>())
        {
            gameObject.GetComponent<Destroyable>().destroy(.1f);
        }

        if (collision.gameObject.GetComponent<Bomb2D>() || collision.gameObject.GetComponent<Coin2D>())
        {
            gameObject.GetComponent<Destroyable>().destroy(.1f);
        }
    }


    

}