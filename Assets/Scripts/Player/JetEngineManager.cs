using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JetEngineManager : MonoBehaviour
{
    [SerializeField]
    float maxFuel; // 최대연료
    float currentFuel; //현재 연료

    [SerializeField]
    float waitFuel; // 재충전 대기 시간
    float currentWaitFeul; //계산

    [SerializeField]
    float reChargeSpeed; //재충전 속도

    [SerializeField]
    Slider slider_jectEngine;
    [SerializeField]
    Text txt_jectEngine;

    public bool isFuel { get; private set; }

    PlayerMovement thePC;
    // Start is called before the first frame update
    void Start()
    {
        currentFuel = maxFuel;
        slider_jectEngine.maxValue = maxFuel;
        slider_jectEngine.value = currentFuel;
        thePC = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        CheckFuel();
        //연료 사용
        UsedFuel();
        
        slider_jectEngine.value = currentFuel;
        //mathf.round 함수로 반올림
        txt_jectEngine.text = Mathf.Round(currentFuel / maxFuel * 100f).ToString() + "%";
    }

    void UsedFuel()
    {
        if (thePC.IsJet == true)
        {
            slider_jectEngine.gameObject.SetActive(true);
            currentFuel -= Time.deltaTime;
            currentWaitFeul = 0;
            if (currentFuel <= 0)
            {
                // 3초되기전에 뛰면 초기화됨
                currentFuel = 0;
            }

        }
        else
        {
            FuelReCharge();
        }

    }
    void FuelReCharge()
    {
        if (currentFuel < maxFuel)
        {
            currentWaitFeul += Time.deltaTime;
            //재충전을 위한 시간동안 충전 했다면
            if (currentWaitFeul >= waitFuel)
            {
                currentFuel += reChargeSpeed * Time.deltaTime;
            }
        }
        else
        {
            ;//currentFuel이 100%가 되면 ui가 안보이게된다
            slider_jectEngine.gameObject.SetActive(false);
        }
    }

    void CheckFuel()
    {
        if (currentFuel > 0)
        {
            isFuel = true;
        }
        else
        {
            isFuel = false;
        }
    }
    //연료 재충전
     
}
