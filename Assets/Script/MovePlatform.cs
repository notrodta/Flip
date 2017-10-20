using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {


    public Transform target1, target2;
    public float speed;

	// Use this for initialization
	void Start () {
        StartCoroutine(MovePlatformCo());
	}
	

    IEnumerator MoveCo(Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            yield return null;
        }
    }

    IEnumerator MovePlatformCo()
    {
        while (true)
        {
            yield return StartCoroutine(MoveCo(target1));
            yield return StartCoroutine(MoveCo(target2));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.parent = this.transform;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
            coll.transform.parent = null;
    }

}
