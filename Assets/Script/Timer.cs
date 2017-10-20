using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {

    public Transform player;
    public Vector3 playerPos;

    public TextMeshPro startText;
    public TextMeshPro timer_text;

    public float time = 30;

    // Use this for initialization
    void Start () {
        playerPos = player.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(playerPos, player.position) > 0.3f)
        {
            startText.gameObject.SetActive(false);
            timer_text.gameObject.SetActive(true);
            playerPos = new Vector3(999,999,999);
        }

        if (timer_text.gameObject.activeInHierarchy)
        {
            time -= Time.deltaTime;
            timer_text.text = System.Math.Round(time, 0) + "";
        }
	}
}
