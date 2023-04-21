using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlataform : MonoBehaviour
{
    public float speed, movementDistance;

    public bool MoveObjectsOnTop;

    float auxMovement;
    bool isLeft, hideGizmos;

    private List<Transform> transformsTop = new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {
        hideGizmos = true;
    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {
        float mov = Time.deltaTime * speed;  // movimento atual
        auxMovement += mov;  // somatório de movimentos

        if(auxMovement <= movementDistance) // está se movendo
        {
            // faz o movimento
            transform.position += transform.right * mov * (isLeft ? +1 : -1);
            if(MoveObjectsOnTop) MoveAllOnTop(mov * (isLeft ? +1 : -1));

        }
        else // movimento chegou no final
        {
            // para impedir que pare antes ou depois do limite
            transform.position += transform.right * (movementDistance - auxMovement + mov) * (isLeft ? +1 : -1);

            if(MoveObjectsOnTop) MoveAllOnTop((movementDistance - auxMovement + mov) * (isLeft ? +1 : -1));

            auxMovement = 0;
            isLeft = !isLeft;
        }

    }


    // movimenta todos os objetos em cima da plataforma
    void MoveAllOnTop(float movement)
    {
        foreach(Transform t in transformsTop)
        {
            t.position += t.right * movement;
        }
    }


    // adiciona objeto à lista de objetos na plataforma
    void OnTriggerEnter2D(Collider2D col)
    {
        if(!transformsTop.Contains(col.transform))
        {
            transformsTop.Add(col.transform);
        }
    }


    // remove objeto da lista de objetos na plataforma
    void OnTriggerExit2D(Collider2D col)
    {
        if(transformsTop.Contains(col.transform))
        {
            transformsTop.Remove(col.transform);
        }
    }


    // Gizmos
    void OnDrawGizmos()
    {
        if(!hideGizmos)
        {
            float lineDistance = 0.8f;

            Gizmos.color = Color.blue;    
            Gizmos.DrawRay(transform.position - (transform.right*movementDistance) + transform.up * lineDistance, 
                           -transform.up * lineDistance * 2);
            
        }
    }
}
