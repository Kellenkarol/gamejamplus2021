using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPonte : MonoBehaviour
{

    public Transform startAnimationPoint,
                        shotPoint,
                            shotDirPoint;

    public float delayToShot;
    public GameObject ball;

    private Animator myAnimator;
    private Transform Player;


    bool alreadyAnimated, playerPassedOfPoint;
    float delayToShotAux;


    // Start is called before the first frame update
    void Start()
    {
        Player      = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myAnimator  = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if(!playerPassedOfPoint)
        {
            playerPassedOfPoint = CheckIfThePlayerHasPassedThePoint();   
        }

        if(playerPassedOfPoint && !alreadyAnimated)
        {
            delayToShotAux += Time.deltaTime;
            if(delayToShotAux >= delayToShot)
            {
                delayToShotAux = 0;
                Shot();
            }
        }
    }


    private void Shot()
    {
        GameObject ballTmp     = Instantiate(ball) as GameObject;
        ballTmp.transform.position = shotPoint.position;
        ballTmp.GetComponent<Rigidbody2D>().AddForce((shotDirPoint.position-shotPoint.position)*5000*Time.deltaTime);
    }


    private void StartAnimation()
    {
        if(!alreadyAnimated)
        {
            alreadyAnimated = true;
            myAnimator.Play("Ponte");
        }
    }


    private bool CheckIfThePlayerHasPassedThePoint()
    {
        return Player.position.x >= startAnimationPoint.position.x;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 9)
        {
            StartAnimation();
        }
    }

}
