using UnityEngine;
using UnityEngine.UI;
using System.Collections;




public class CreateDanMu : MonoBehaviour {


    public GameObject DanMuTextPrefeb;
    private GameObject Panel;

    public InputField inputField;

    void Awake()
    {
        Panel = transform.Find("Panel").gameObject;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //随机一条颜色
            Color color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));

            DanMuPosType posType = DanMuPosType.RightToLeft;
            int dur = Random.Range(0, 5);
            dur = 2;
            switch (dur)
            {
                case 0:
                    posType = DanMuPosType.RightToLeft;
                    break;
                case 1:
                    posType = DanMuPosType.LeftToRight;
                    break;

                case 2:
                    posType = DanMuPosType.TopToBottom;
                    break;

                case 3:
                    posType = DanMuPosType.BottomToTop;
                    break;

                case 4:
                    posType = DanMuPosType.Stay;
                    break;
                
            }


            CreateOneDanMu("我是弹幕我是弹幕我是弹幕我是弹幕我是弹幕我是弹幕", color, posType, Random.Range(10f, 15f));
        }
    }

    void CreateOneDanMu(string showStr, Color showColor, DanMuPosType posType, float ShowSpeed)
    {
        GameObject newText = GameObject.Instantiate(DanMuTextPrefeb) as GameObject;
        newText.GetComponent<DanMuText>().Create(showStr, showColor, posType, ShowSpeed);
        newText.transform.parent = Panel.transform;
    }

    public void OnSendClick()
    {
        if (inputField.text!="")
        {
            Color color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));

            DanMuPosType posType = DanMuPosType.RightToLeft;
            int dur = Random.Range(0, 5);
            
            switch (dur)
            {
                case 0:
                    posType = DanMuPosType.RightToLeft;
                    break;

                case 1:
                    posType = DanMuPosType.LeftToRight;
                    break;

                case 2:
                    posType = DanMuPosType.TopToBottom;
                    break;

                case 3:
                    posType = DanMuPosType.BottomToTop;
                    break;

                case 4:
                    posType = DanMuPosType.Stay;
                    break;

            }


            CreateOneDanMu(inputField.text, color, posType, Random.Range(10f, 15f));

            inputField.text = "";
        }
    }
}
