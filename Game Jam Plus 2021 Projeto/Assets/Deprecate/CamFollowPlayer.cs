using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    private Transform PlayerTrans;

    public float smoothSpeed = 8f, speed;
    public Vector3 offset;
    public Transform limiteLeft, limiteRight;
    private 

    // Start is called before the first frame update
    void Start()
    {
        PlayerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Vector3 desiredPosition = PlayerTrans.position + offset;
        // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);



        float dir = (PlayerTrans.position-transform.position).x;
        float movement = dir*speed*Time.deltaTime;
        Vector3 newPos = new Vector3(transform.position.x+movement,
                                            transform.position.y,
                                                transform.position.z);

        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 stageDimensions2 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));

        if(stageDimensions.x+movement >= limiteLeft.position.x && stageDimensions2.x+movement <= limiteRight.position.x)
            transform.position = newPos;






    }
}
