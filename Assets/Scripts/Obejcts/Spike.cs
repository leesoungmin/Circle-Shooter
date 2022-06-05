using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField]
    int Dmg = 1;

    [SerializeField]
    float force;

    private void OnCollisionEnter(Collision other)
    {
        // 충돌한 오브젝트의 태그가 Player라면 실행
        if(other.transform.CompareTag("Player"))
        {
            //Debug.Log(other.gameObject.name);
            Debug.Log(Dmg + "를 입힘");
            //AddExplosionForce 폭발 반경내에 있는 다른 rigidBody를 날려보냄
            other.transform.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, 5f);
            other.transform.GetComponent<StatusManager>().DecreaseHp(Dmg);
        }
    }
}
