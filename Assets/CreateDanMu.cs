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
            CreateRandomDanmu("我是弹幕我是弹幕我是弹幕我是弹幕我是弹幕");
        }
    }

    void CreateOneDanMu(string showStr, Color showColor, DanMuPosType posType, float ShowSpeed)
    {
        GameObject newText = GameObject.Instantiate(DanMuTextPrefeb) as GameObject;
        newText.GetComponent<DanMuText>().Create(showStr, showColor, posType, ShowSpeed);
        newText.transform.parent = Panel.transform;
    }

    void CreateRandomDanmu(string showstr)
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


        CreateOneDanMu(showstr, color, posType, Random.Range(10f, 15f));
    }

    public void OnSendClick()
    {
        if (inputField.text!="")
        {

            CreateRandomDanmu(inputField.text);
            inputField.text = "";
        }
    }
}
