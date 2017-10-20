using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateObject : MonoBehaviour {

    public Transform target1, target2;
    public float speed;

    // Use this for initialization
    void Start()
    {
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

}
