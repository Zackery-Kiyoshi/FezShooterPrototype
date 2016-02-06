using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform objectToTrack;

    private Vector3 distance;

    // Use this for initialization
    void Start()
    {
        distance =  gameObject.transform.position - objectToTrack.transform.position;
        Camera camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToTrack != null)
        {
            transform.position = objectToTrack.position + distance;
        }
    }

    public void giveCameraFocusTo(Transform newFocusObject)
    {
        Camera camera = Camera.main;
        if (camera != null)
        {
            objectToTrack = newFocusObject;
        }
    }
}
