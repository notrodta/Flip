using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour {

    public static DeathCounter instance;

    public TextMeshPro counter;
    public static int death = 0;

    // Use this for initialization
    void Start () {
        instance = this;
        instance.counter.text = death.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void IncrementDeath()
    {
        death++;
        instance.counter.text = death.ToString();
    }

}
