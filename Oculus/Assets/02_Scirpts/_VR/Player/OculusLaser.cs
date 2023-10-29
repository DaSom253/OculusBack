using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OculusLaser : MonoBehaviour
{
    public enum HandType
    {
        LeftHand, RightHand
    }
    public HandType handType; //왼손 오른손 구분

    public OculusCon player; //오큘러스 플레이어

    private LineRenderer line; //라인렌더러
    private float maxDistance = 3f; //레이저 최대 거리
    public GameObject hitObject; //레이저가 충돌한 물체 -> 레이저가 감지한 물체
    // Start is called before the first frame update
    void Start()
    {
        //이 스크립트 부착된 오브젝트에서 LineRenderer라는 컴포넌트를 찾아서 line에 연결한다.
        line = GetComponent<LineRenderer>();

        line.SetPosition(0, Vector3.zero); //라인의 시작점 설정 (시작점, 시작점의 위치)

        line.SetPosition(1, transform.forward * maxDistance); //라인의 마지막 지점 설정 (시작점, 시작점의 위치)
    }

    // Update is called once per frame
    void Update()
    {
        ////이 스크립트 부착된 오브젝트에서 LineRenderer라는 컴포넌트를 찾아서 line에 연결한다.
        //line = GetComponent<LineRenderer>();

        //line.SetPosition(0, transform.position); //라인의 시작점 설정 (시작점, 시작점의 위치)

        //line.SetPosition(1, transform.forward * maxDistance); //라인의 마지막 지점 설정 (시작점, 시작점의 위치)
        //(0, 0, 1) * 30.0f = (0, 0, 30) -> 라인의 길이 지정


        RaycastHit hit;//충돌체 정보

        //만약에 레이가 충돌한다면(레이 발사 위치, 레이 발사 방향, 충돌 정보, 레이의 길이)
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            //레이가 충돌한 물체를 hitObject에 담는다.
            hitObject = hit.transform.gameObject;
        }

        //레이가 충돌하지 않는다면
        else
        {
            //hitObject를 비운다.
            hitObject = null;
        }

        switch (handType)
        {
            //왼손일 경우
            case HandType.LeftHand:
                {
                    //플레이어의 왼손에 충돌체 정보를 담는다.
                    player.grabL = hitObject;
                    break;
                }

            //오른손일 경우
            case HandType.RightHand:
                {
                    //플레이어의 오른손에 충돌체 정보를 담는다.
                    player.grabR = hitObject;
                    break;
                }
        }

        if (hitObject)
        {
            switch (hitObject.transform.name)
            {
                case "KeyPad_Col":
                    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                    {
                        Keypad.s.KeyPad_Col_Open = true;
                        break;
                    }
                    break;
                case "KeyPad_1":
                    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                    {
                        KeyPadOpen.instance.Ans.text += 1.ToString();
                        break;
                    }
                    break;
                case "KeyPad_2":
                    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                    {

                    }
                    break;
                case "KeyPad_3":
                    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                    {

                    }
                    break;
                case "KeyPad_4":
                    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                    {

                    }
                    break;
                case "KeyPad_5":
                    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                    {

                    }
                    break;
                case "KeyPad_6":
                    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                    {

                    }
                    break;
                case "KeyPad_7":
                    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                    {

                    }
                    break;
                case "KeyPad_8":
                    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                    {

                    }
                    break;
                case "KeyPad_9":
                    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                    {

                    }
                    break;


            }
        }
        

    }
}
