using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [Header("현재 장착된 촉")]
    [SerializeField] Gun[] currentGun;
    [SerializeField] int currentGunCount;

    [SerializeField] Text txt_CurrentGunBullet;

    [SerializeField] PlayerMovement the_PM;

    float currentFireRate;
    // Start is called before the first frame update
    void Start()
    {
        currentFireRate = 0;
        BulletUIset();
    }

    public void BulletUIset()
    {
        txt_CurrentGunBullet.text = "x " + currentGun[currentGunCount].bulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        FireRateCalc();
        TryFire();
        LockOnMouse();

        if(currentGun[0].bulletCount > currentGun[0].maxBulletCount)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            currentGun[0].bulletCount += 5;
        }
    }

    void FireRateCalc()
    {
        if(currentFireRate > 0 ) 
            currentFireRate -= Time.deltaTime;
            
    }
    void TryFire()
    {
        if(Input.GetButton("Fire1") && currentGun[currentGunCount].bulletCount > 0 && PlayerMovement.cnaMove)
        {
            if(currentFireRate <= 0)
            {
                currentFireRate = currentGun[currentGunCount].fireRate;
                Fire();

            }
        }
    }
    void Fire()
    {
        currentGun[currentGunCount].bulletCount--;
        BulletUIset();
        currentGun[currentGunCount].ps_MuzzleFlash.Play();
        currentGun[currentGunCount].gun_Fire.SetTrigger("Gun_Fire");
        if(currentGunCount == 2)
        {
            currentGun[currentGunCount].shot_Fire.SetTrigger("Fire_Shot");
        }
        SoundManager.instance.PlaySE(currentGun[currentGunCount].sound_Fire);

        //var 변수의 타입을 모를떄 사용 프리팹은 GameObject로 받을수있다.
        //Instantiate 프리팹 생성 함수
        var clone = Instantiate(currentGun[currentGunCount].go_Bullet_Prefab, currentGun[currentGunCount].ps_MuzzleFlash.transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * currentGun[currentGunCount].speed); 
    }
    void LockOnMouse()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, cameraPos.x));
        Vector3 target = new Vector3(0f, mousePos.y, mousePos.z);
        transform.LookAt(target);
    }
}
