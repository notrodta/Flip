using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBlade : MonoBehaviour {

    public GameObject pivot;
    public float spinningSpeed = 10;

    public bool randomPivot;


	// Use this for initialization
	void Start () {
        if (randomPivot)
            pivot.transform.eulerAngles = new Vector3(0, 0, Random.Range(0,360));
    }
	
	// Update is called once per frame
	void Update () {
        pivot.transform.Rotate(0, 0, 20 * Time.deltaTime * spinningSpeed);
    }
}
