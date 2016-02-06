using UnityEngine;
using System.Collections;

public class Corner4Screen : MonoBehaviour {

    public int side1;
    public int side2;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider p)
    {

        CornerPlayer player = p.GetComponent<CornerPlayer>();
        //Debug.Log("TRIGGER, p:" + player.camPos);
        if (player.camPos == side1)
        {
            player.camPos = side2;
        }
        else if (player.camPos == side2)
        {
            player.camPos = side1;
        }
    }

}
