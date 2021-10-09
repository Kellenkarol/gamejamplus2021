using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]Rigidbody2D _rbPersonagem;
    int _personVelocityMax = 700;
    float _velocityX=0;
    [SerializeField]float _moveX;
    [SerializeField] Animator animatorPersonagem;
    [SerializeField] Transform GroundCheck;
    [SerializeField]bool _isFloor;
    BoxCollider2D boxPersonage;
    // Start is called before the first frame update
    void Start()
    {
        boxPersonage = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveX = Input.GetAxisRaw("Horizontal");
        if (_moveX == 0)
        {
            animatorPersonagem.SetInteger("MoveVelocity", 0);
            _velocityX = 0;
        }
        else
        {
            animatorPersonagem.SetInteger("MoveVelocity", 1);
            transform.localScale = new Vector3(_moveX,1,1);
        }
        _isFloor = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Floor"));

        if (Input.GetKeyDown(KeyCode.Space) && _isFloor)
        {
            ExecuteJump();
        }
    }

    private void FixedUpdate()
    {
        if (_velocityX < _personVelocityMax)
        {
            _velocityX += 550 * Time.deltaTime;
        }
        else
        {
            _velocityX = 700;
        }
        _rbPersonagem.velocity = new Vector2(_moveX * _velocityX * Time.deltaTime, _rbPersonagem.velocity.y);


    }
    void ExecuteJump()
    {
        _rbPersonagem.AddForce(new Vector2(0, 1500));
    }
}
