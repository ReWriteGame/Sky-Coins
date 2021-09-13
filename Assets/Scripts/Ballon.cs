using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ballon : MonoBehaviour
{
    public UnityEvent TakeCoinEvent;
    public UnityEvent TakeBombEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bomb2D>())
        {
            gameObject.GetComponent<Destroyable>().destroy(.1f);
            TakeBombEvent?.Invoke();
        }

       

        if (collision.gameObject.GetComponent<Brick2D>())
        {
            gameObject.GetComponent<Destroyable>().destroy(.1f);
            TakeBombEvent?.Invoke();

        }
        if (collision.gameObject.GetComponent<Coin2D>())
        {
            TakeCoinEvent?.Invoke();

        }
    }
}
