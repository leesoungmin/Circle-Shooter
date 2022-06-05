using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header("따라갈 속도 조정")]
    [Range(0, 1f)]
    [SerializeField] float chaseSpeed;

    [Header("카메라가 따라갈 대상")]
    [SerializeField] Transform tf_Player;

    float camXpos;
    [Header("부스터시 떨어질 x거리")]
    [SerializeField]
    float camJetXpos;
    float CamCurrentXpos;

    PlayerMovement thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = tf_Player.GetComponent<PlayerMovement>();
        camXpos = transform.position.x;
        CamCurrentXpos = camXpos;
    }

    // Update is called once per frame
    void Update()
    {
        if(thePlayer.IsJet)
        {
            CamCurrentXpos = camJetXpos;
            
        }
        else
        {
            CamCurrentXpos = camXpos;
        }
        Vector3 movePos = Vector3.Lerp(transform.position, tf_Player.position, chaseSpeed);
        transform.position = new Vector3(movePos.x + 1  , movePos.y, movePos.z);
    }
}
