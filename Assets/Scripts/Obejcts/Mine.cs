using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] float verticalDistance; //수직 움직임
    [SerializeField] float horizontalDistace; //수평 움직임

    [Range(0, 1)]
    [SerializeField] float moveSpeed; //움직임의 스피드
    [SerializeField] int Hp;
    [SerializeField] int Dmg;
    [SerializeField] GameObject go_EffectPrefab;

    //목적지
    Vector3 endPos1;
    Vector3 endPos2;

    //현재 
    Vector3 currentDestination;

    void Start()
    {
        Vector3 originPos = transform.position;
        endPos1.Set(originPos.x, originPos.y + verticalDistance, originPos.z + horizontalDistace);
        endPos2.Set(originPos.x, originPos.y - verticalDistance, originPos.z - horizontalDistace);
        currentDestination = endPos1;
    }

    void Update()
    {
        if ((transform.position - endPos1).sqrMagnitude <= 0.1f)
            currentDestination = endPos2;
        else if((transform.position - endPos2).sqrMagnitude <= 0.1f)
            currentDestination = endPos1;

        transform.position = Vector3.Lerp(transform.position, currentDestination, moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Player")
        {
            collision.transform.GetComponent<StatusManager>().DecreaseHp(Dmg);
            Explosion();
        }
        
    }

    

    public void Damaged(int _num)
    {
        Hp -= _num;
        if(Hp<=0)
        {
            Explosion();
        }
    }

    void Explosion()
    {
        
        SoundManager.instance.PlaySE("Boom");
        GameObject clone = Instantiate(go_EffectPrefab, transform.position, Quaternion.identity);
        Destroy(clone, 2f);
        Destroy(gameObject);
    }
}
