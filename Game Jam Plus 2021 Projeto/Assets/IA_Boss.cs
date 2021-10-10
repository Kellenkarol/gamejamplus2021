using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Boss : MonoBehaviour
{

    public GameObject Ball, 
                      Wolf;


    public Transform SpawnPoint_X, 
                     SpawnPoint_Y, 
                     limiteLeft, 
                     limiteRight,
                     Player;


    public float BallDelaySpawn, 
                 BallDelaySpawnVariance, 
                 BallRainCount, 
                 BallRainDelayBetweenBall, 
                 WolfDelaySpawn, 
                 WolfDelaySpawnVariance; 


    public Collider2D ColliderOnFace;


    private float wolfSpawnAux, 
                  currentWolfDelaySpawn, 
                  currentBallDelaySpawn, 
                  BallRainDelayBetweenBallAux;


    public int maxWolfSameTime;
    

    private List<GameObject> wolfOn  = new List<GameObject>();
    private List<GameObject> wolfOff = new List<GameObject>();

    private List<GameObject> ballOn  = new List<GameObject>();
    private List<GameObject> ballOff = new List<GameObject>();


    int currentBallAttack = 0, BallRainCountAux;
    bool BallAttackChosen = false;
    float wolfCountAux, ballSpawnAux;


    // Start is called before the first frame update
    void Start()
    {
        currentWolfDelaySpawn = WolfDelaySpawn + Random.Range(0, WolfDelaySpawnVariance);
        currentBallDelaySpawn = BallDelaySpawn + Random.Range(0, BallDelaySpawnVariance);
    }

    // Update is called once per frame
    void Update()
    {
        wolfSpawnAux += Time.deltaTime;
        ballSpawnAux += Time.deltaTime;

        if(wolfSpawnAux >= currentWolfDelaySpawn)
        {
            wolfSpawnAux = 0;
            currentWolfDelaySpawn = WolfDelaySpawn + Random.Range(0, WolfDelaySpawnVariance);


            // spawn somente se quantidade de lobos inferior ao limite máximo
            if(wolfOn.Count < maxWolfSameTime)
            {
                GameObject _wolf = CreateWolf();
                _wolf.transform.position = new Vector3(Random.Range(limiteLeft.position.x, limiteRight.position.x), 
                                                       SpawnPoint_X.position.y,
                                                       SpawnPoint_X.position.z);

            }


        }


        if(ballSpawnAux >= currentBallDelaySpawn)
        {
            // escolhe o tipo de ataque
            if(!BallAttackChosen)
            {
                BallAttackChosen = true;
                currentBallAttack = Random.Range(0,1); // incrementar o 1 quando adicionar um novo ataque
            }

            // chuva
            if(currentBallAttack == 0)
            {
                BallRainDelayBetweenBallAux += Time.deltaTime;

                // espera o tempo entre cada bola
                if(BallRainDelayBetweenBallAux >= BallRainDelayBetweenBall)
                {
                    BallRainDelayBetweenBallAux = 0;
                    BallRainCountAux++;

                    // criar enquanto menor que quantidade máxima
                    if(BallRainCountAux <= BallRainCount)
                    {
                        GameObject _ball = CreateOneBallRain();
                        _ball.transform.position = new Vector3(Random.Range(limiteLeft.position.x, limiteRight.position.x), 
                                                               SpawnPoint_Y.position.y,
                                                               SpawnPoint_Y.position.z);
                    }
                    else
                    {
                        // fim, então é necessário resetar as variáveis
                        BallRainCountAux = 0;
                        ballSpawnAux = 0;
                        currentBallDelaySpawn = BallDelaySpawn + Random.Range(0, BallDelaySpawnVariance);
                        BallAttackChosen = false;
                    }
                }
            }
            else
            {
                // a bola vem rolando até o jogador
            }
        }


        // ataque se chegar perto
        if(IsInside(ColliderOnFace, Player.position))
        {
            print("Player is inside collider, ATTAAAACK!!!");

        }

    }


    private GameObject CreateWolf()
    {
        GameObject wolfTmp;
        if(wolfOff.Count != 0)
        {
            wolfTmp = wolfOff[0];
            wolfOff.RemoveAt(0);

            wolfTmp.SetActive(true);
            wolfOn.Add(wolfTmp);
        }
        else
        {
            wolfTmp = Instantiate(Wolf) as GameObject;
            wolfTmp.GetComponent<AI_Enemy>()._isOnBoss = true;
            wolfTmp.GetComponent<AI_Enemy>().bossScript = this;
            wolfOn.Add(wolfTmp);
        }

        return wolfTmp;
    }


    public void RemoveWolf(GameObject obj)
    {
        GameObject wolfTmp;
        if(wolfOn.Contains(obj))
        {
            int idx = wolfOn.IndexOf(obj);
            wolfTmp = wolfOn[idx];
            wolfOn.Remove(wolfTmp);
            wolfTmp.SetActive(false);
            wolfOff.Add(wolfTmp);
        }

    }


    private GameObject CreateOneBallRain()
    {
        GameObject ballTmp;
        if(ballOff.Count != 0)
        {
            ballTmp = ballOff[0];
            ballOff.RemoveAt(0);

            ballTmp.SetActive(true);
            ballOn.Add(ballTmp);
        }
        else
        {
            ballTmp = Instantiate(Ball) as GameObject;
            ballOn.Add(ballTmp);
        }

        return ballTmp;
    }


    public void RemoveBallRain(GameObject obj)
    {
        GameObject ballTmp;
        if(ballOn.Contains(obj))
        {
            int idx = ballOn.IndexOf(obj);
            ballTmp = ballOn[idx];
            ballOn.Remove(ballTmp);
            ballTmp.SetActive(false);
            ballOff.Add(ballTmp);
        }

    }


    public static bool IsInside(Collider2D c, Vector3 point)
    {
        Vector2 dir = point - c.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(c.transform.position, dir, Mathf.Infinity, LayerMask.GetMask("Player"));

        Vector2 closest = c.ClosestPoint(hit.point);
        // Because closest=point if point is inside - not clear from docs I feel
        return closest == hit.point;
    }


}
