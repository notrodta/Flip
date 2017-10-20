using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().respwanPoint = this.gameObject.transform;
            //this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }


}
