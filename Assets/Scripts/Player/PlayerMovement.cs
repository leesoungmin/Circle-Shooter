using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("속도 관련 변수")]
    [SerializeField]
    private float Speed = 10;
    [SerializeField]
    private float JetSpeed = 15;

    public static bool cnaMove = true;

    Rigidbody p_rigid;
    AudioSource audioSource;
    SpriteRenderer p_rend;

    JetEngineManager theFuel;

    //프로포티(은닉)
    //변수를 보호하거나 숨겨서 노출을 최소화
    //다른곳에서 참조가 가능하지만 다른 스크립트에서 수정을 못함
    public bool IsJet { get; private set; }

    [Header("파티클 시스템(부스터)")]
    [SerializeField] ParticleSystem ps_LeftEngine;
    [SerializeField] ParticleSystem ps_RightEngine;

    // Start is called before the first frame update
    void Start()
    {
        cnaMove = true;
        IsJet = false;
        p_rigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        p_rend = GetComponent<SpriteRenderer>();
        theFuel = FindObjectOfType<JetEngineManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TryMove();
        TryJet();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    void TryMove()
    {
        //float horizontal;

        //horizontal = Input.GetAxis("Horizontal");

       
        //Vector3 velocity = new Vector3(0f, 0f, horizontal);
        //p_rigid.AddForce(velocity * Speed);

        if (Input.GetAxisRaw("Horizontal") != 0 && cnaMove)
        {
            // d =1 , a = -1
            Vector3 moveDir = new Vector3(0, 0, Input.GetAxisRaw("Horizontal"));
            p_rigid.AddForce(moveDir * Speed);
        }
    }

    void TryJet()
    {
        if(Input.GetKey(KeyCode.Space) && theFuel.isFuel == true && cnaMove)
        {
            if(!IsJet )
            {
                audioSource.Play();
                ps_LeftEngine.Play();
                ps_RightEngine.Play();
                IsJet = true;
            }
            p_rigid.AddForce(Vector3.up * JetSpeed);
        }
        else
        {
            if (IsJet)
            {
                ps_LeftEngine.Stop();
                ps_RightEngine.Stop();
                audioSource.Stop();
                IsJet = false;
            }
            p_rigid.AddForce(Vector3.down * JetSpeed);
        }
    }
}
