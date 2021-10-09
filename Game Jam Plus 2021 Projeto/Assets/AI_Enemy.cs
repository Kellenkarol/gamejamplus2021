using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// stand by - OK
// seguir - OK
// atacar - +/-
// pular 
// defesa?


public class AI_Enemy : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed, attackDistance, attackSpeed, attackDelay, standByMovementDistance;
    [SerializeField]
    private Vector2 visionDistance;

    public Transform Player;
    // public bool isOnPlataform;

    Vector3 playerDistance;
    float movementDistance, currentMovementDistance, distanceOfPlayer, attackDelayAux;
    bool standBy, isLeft, isAttacking, attackIn, jumping, isMov;

    // Start is called before the first frame update
    void Start()
    {
        standBy = true;
        if(standBy)
            movementDistance = (int)(standByMovementDistance/2);
        // movementDistance=0;
        isMov =true;
    }

    // Update is called once per frame
    void Update()
    {

        if(isMov)
        {
            attackDelayAux = 0;
            Move();
        }
        if(isAttacking)
        {
            attackDelayAux += Time.deltaTime;
            if(attackDelayAux >= attackDelay)
                Attack();
        }
        

    }

    void Jump()
    {

    }


    bool IsInRangeAttack()
    {
        return Mathf.Abs(playerDistance.x) <= attackDistance && Mathf.Abs(playerDistance.y) <= 0.3;
    }


    // faz o inimigo atacar
    private void Attack()
    {
        print("Atacando");
        currentMovementDistance = Time.deltaTime * attackSpeed;
        movementDistance += currentMovementDistance;

        float attackAux = -1;

        if(isLeft)
        {
            attackAux = 1;
            if(attackIn)
                attackAux = -1;
        }
        else
        {
            attackAux = -1;
            if(attackIn)
                attackAux = 1;
        }
     
        if(movementDistance >= distanceOfPlayer+0.2f)
        {
            currentMovementDistance = movementDistance - (distanceOfPlayer+0.2f);
            movementDistance = 0;
            if(attackIn)
            {
                attackIn = false;
            }
            else
            {
                isAttacking = false;
                attackIn = true;
                isMov = true;
                // print("End position: "+transform.position);
            }
            // print("movementDistance"+movementDistance);
        }
        // print("currentMovementDistance  "+currentMovementDistance+",   movementDistance  "+movementDistance);

        transform.position += transform.right * attackAux * currentMovementDistance;

    }


    //movimenta o inimigo
    private void Move()
    {
        playerDistance = GetDistance(transform.position, Player.position);
        standBy = true;

        if(Mathf.Abs(playerDistance.x) <= visionDistance.x &&
           Mathf.Abs(playerDistance.y) <= visionDistance.y)
            standBy = false;


        currentMovementDistance = Time.deltaTime * movementSpeed;
        movementDistance += currentMovementDistance;


        if(standBy)
        {
            if(movementDistance >= standByMovementDistance)
            {
                movementDistance = 0;
                isLeft = !isLeft;
            }
        }
        else
        {
            movementDistance = 0;
            isLeft = true;
            if(Player.position.x > transform.position.x)
                isLeft = false;
        }

        transform.position += transform.right * (isLeft ? -1:1) * currentMovementDistance;


        // ataque        
        if(IsInRangeAttack())
        {
            distanceOfPlayer = GetDistanceOfPlayer();
            movementDistance = 0;
            attackIn = true;
            isAttacking = true;
            isMov = false;
        }
    }


    private Vector3 GetDistance(Vector3 a, Vector3 b)
    {
        Vector3 d = b-a;
        return new Vector3(Mathf.Abs(d.x),Mathf.Abs(d.y),Mathf.Abs(d.z));
    }


    // verifica colisão
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            print("Ataquei");
            // acessar o script do player e efetuar o dado
        }
    }


    // retorna a distancia (Magnitude) entre dois pontos
    public static float CalculateDistance(Vector2 a, Vector2 b)
    {
        // formula -----------------------------------------------
        // raiz quadrada de ( ( x'' - x' ) ^ 2 + ( y'' - y' ) ^ 2)
        return Mathf.Pow(Mathf.Pow(b.x-a.x, 2)+Mathf.Pow(b.y-a.y, 2), 0.5f);
    }


    private float GetDistanceOfPlayer()
    {
        Vector2 dir = Player.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, Mathf.Infinity, LayerMask.GetMask("Player"));

        dir = transform.position - Player.position;
        RaycastHit2D hit2 = Physics2D.Raycast(Player.position, dir, Mathf.Infinity, LayerMask.GetMask("Enemie"));

        return CalculateDistance(hit.point, hit2.point);
    }


    float GetDistanceOfLeftOrRight(bool _isleft)
    {
        Vector2 dir = _isleft ? -Vector2.right:Vector2.right;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, Mathf.Infinity, LayerMask.GetMask("Collisor"));
        return CalculateDistance(transform.position, hit.point);
    }

}
