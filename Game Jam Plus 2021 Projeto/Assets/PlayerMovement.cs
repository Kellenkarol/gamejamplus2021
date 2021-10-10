using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]Rigidbody2D _rbPersonagem;
    int _personVelocityMax = 400;
    float _velocityX=0;
    [SerializeField]float _moveX;
    [SerializeField] Animator animatorPersonagem;
    [SerializeField] Transform GroundCheck;
    [SerializeField]bool _isFloor;
    [SerializeField] bool _isIvencibility;
    [SerializeField]PlayerHability playerHability;
    [SerializeField]int lifePersonage=3;
    [SerializeField]bool personagemParado = false;
    float timerHabilityDefense=3;
    float maxTimerHabilityDefense=3;
    public float TimerDefense
    {
        get { return timerHabilityDefense; }
        set
        {
            timerHabilityDefense = value;
            Event.OnUIDefenseAmount(CalculateFillAmount());
            if (timerHabilityDefense <= 0)
            {
                animatorPersonagem.SetBool("Defense", false);
                DesativarHabilidadeEscudo();
            }
            else
            {
                if(timerHabilityDefense>= maxTimerHabilityDefense)
                {
                    timerHabilityDefense = maxTimerHabilityDefense;
                }
            }
        }
    }
    public int Life
    {
        get { return lifePersonage; }
        set
        {
            if (lifePersonage > 0)
            {
                lifePersonage = value;
                if (lifePersonage == 0)
                {
                    Event.OnPersonageDie();
                    StartCoroutine(DieAnim());
                    Debug.Log("Die");
                }
                else
                {
                    Event.OnPersonageTakeDamage(lifePersonage);
                    StartCoroutine(TakeDamageAnim());
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage();
        }
        _moveX = Input.GetAxisRaw("Horizontal");
        if (_moveX == 0)
        {
            animatorPersonagem.SetInteger("MoveVelocity", 0);
            _velocityX = 0;
        }
        else
        {
            if (!personagemParado)
            {
                animatorPersonagem.SetInteger("MoveVelocity", 1);
                transform.localScale = new Vector3(_moveX * 0.2f, 0.2f, 0.2f);
            }
            else
            {
                animatorPersonagem.SetInteger("MoveVelocity", 0);
            }

        }
        _isFloor = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Floor"));

        if (Input.GetKeyDown(KeyCode.Space) && _isFloor && playerHability.PossuiHabilidade(Habilidades.Habilidade.Pulo))
        {
            ExecuteJump();
        }
        if (Input.GetKeyDown(KeyCode.E) && playerHability.PossuiHabilidade(Habilidades.Habilidade.Defesa))
        {
            //Ativar habilidade
            animatorPersonagem.SetBool("Defense", true);
            AtivarHabilidadeEscudo();
            TimerDefense -= Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.E)&& playerHability.PossuiHabilidade(Habilidades.Habilidade.Defesa))
        {
            //Ativar habilidade
            animatorPersonagem.SetBool("Defense", false);
            DesativarHabilidadeEscudo();
            TimerDefense += Time.deltaTime;
        }

        if(_isIvencibility)
            TimerDefense -= Time.deltaTime;
        else
            TimerDefense += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (!personagemParado)
        {
            if (_velocityX < _personVelocityMax)
            {
                _velocityX += 300 * Time.deltaTime;
            }
            else
            {
                _velocityX = _personVelocityMax;
            }
            _rbPersonagem.velocity = new Vector2(_moveX * _velocityX * Time.deltaTime, _rbPersonagem.velocity.y);
        }
    }
    void ExecuteJump()
    {
        _rbPersonagem.AddForce(new Vector2(0, 800));
    }

    void AtivarHabilidadeEscudo()
    {

        _isIvencibility = true;
    }

    void DesativarHabilidadeEscudo()
    {
        _isIvencibility = false;
    }

    public void TakeDamage()
    {
        Life -= 1;
    }

    IEnumerator TakeDamageAnim()
    {
        animatorPersonagem.SetTrigger("TakeDamage");
        personagemParado = true;
        yield return new WaitForSeconds(1);
        personagemParado = false;
    }

    IEnumerator DieAnim()
    {
        animatorPersonagem.SetTrigger("Die");
        personagemParado = true;
        yield return new WaitForSeconds(1);
    }

    public float CalculateFillAmount()
    {
        float result = timerHabilityDefense/ maxTimerHabilityDefense;
        result = Mathf.Clamp(result, 0,100);
        return result;
    }
}
