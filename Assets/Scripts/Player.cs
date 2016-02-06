using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public FezCameraScript cam;

    // Front:0 Left:1 Back:2 Right:3
    int camPos = 0;
    bool crouch = false;
    float speed = 10;
    Rigidbody body;

    public int jumpTime;
    public int JumpForce;
    private int jumpTmp;

    private GameObject front;
    private float dist = 0.75f;
    private Vector3 oldPos;
    private bool jumped1 = false;

    public KeyCode RotateLeft;
    public KeyCode RotateRight;
    public KeyCode Jump;
    public KeyCode Crouch;
    public KeyCode Left;
    public KeyCode Right;

    private int rotTmp = 0;
    private int rotTime = 5;

    // Use this for initialization
    void Start()
    {
        jumpTmp = jumpTime;
        front = gameObject.transform.Find("Sphere").gameObject;
        body = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void rotateCam()
    {
            if (camPos == 0)
            {
                cam.Front();
            }
            else if (camPos == 1)
            {
                cam.Left();
            }
            else if (camPos == 2)
            {
                cam.Back();
            }
            else if (camPos == 3)
            {
                cam.Right();
            }
        Debug.Log("CamPos:" + camPos);
    }

    void FixedUpdate()
    {
        int tmpPos = camPos;
        if (rotTmp <= 0)
        {
            if (Input.GetKey(RotateRight))
            {
                //Debug.Log("DELETE");
                if (camPos != 3) camPos++;
                else camPos = 0;
                rotateCam();
                rotTmp = rotTime;
            }
            else if (Input.GetKey(RotateLeft))
            {
                //Debug.Log("Page");
                if (camPos != 0) camPos--;
                else camPos = 3;
                rotateCam();
                rotTmp = rotTime;
            }
        }
        else
        {
            rotTmp--;
        }

        if (Input.GetKey(Crouch))
        {
            // Crouch
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            //dist -= .4f;
            crouch = true;
        }
        else
        {
            if (crouch == true)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                //dist += .4f;
                crouch = false;
            }
        }

        Vector3 tmpFront = new Vector3(0, 0, 0);
        if (Input.GetKey(Left))
        {
            // Left
            if (camPos == 0) tmpFront = new Vector3(-1, 0, 0);
            else if (camPos == 1) tmpFront = new Vector3(0, 0, -1);
            else if (camPos == 2) tmpFront = new Vector3(1, 0, 0);
            else if (camPos == 3) tmpFront = new Vector3(0, 0, 1);
            body.AddForce(tmpFront * speed);
            front.transform.position = tmpFront * dist + gameObject.transform.position;
            oldPos = gameObject.transform.position;
        }
        else if (Input.GetKey(Right))
        {
            // Right
            if (camPos == 0) tmpFront = (new Vector3(1, 0, 0));
            else if (camPos == 1) tmpFront = (new Vector3(0, 0, 1));
            else if (camPos == 2) tmpFront = (new Vector3(-1, 0, 0));
            else if (camPos == 3) tmpFront = (new Vector3(0, 0, -1));
            body.AddForce(tmpFront * speed);
            front.transform.position = tmpFront * dist + gameObject.transform.position;
            oldPos = gameObject.transform.position;
        }
        else
        {
            /*
            if (oldPos != gameObject.transform.position)
                front.transform.position += gameObject.transform.position - oldPos; 
            */
        }

        if (Input.GetKey(Jump))
        {
            if (!jumped1) {
                body.AddForce(new Vector3(0, JumpForce, 0));
                jumped1 = true;
            }
            else
            {
                if(jumpTmp != 0)
                {
                    jumpTmp--;
                }
                else
                {
                    jumped1 = false;
                    jumpTmp = jumpTime;
                }
            }
            // Jump
            
        }

    }
}
