using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public enum DanMuPosType
{
    RightToLeft,//从右往左
    LeftToRight,//
    TopToBottom,
    BottomToTop,
    Stay//保持一段时间后消失
}

public class DanMuText : MonoBehaviour
{

    private string showStr;

    public string ShowStr
    {
        get { return showStr; }
        set { showStr = value; }
    }
    private Color showColor;

    public Color ShowColor
    {
        get { return showColor; }
        set { showColor = value; }
    }
    private DanMuPosType posType;

    public DanMuPosType PosType
    {
        get { return posType; }
        set { posType = value; }
    }
    private float showTime;

    public float ShowTime
    {
        get { return showTime; }
        set { showTime = value; }
    }

    private Text text;

    void Awake()
    {
        text = this.GetComponent<Text>();
    }

    public void Create(string showStr, Color showColor, DanMuPosType posType, float showTime)
    {

        //显示字
        ShowStr = showStr;
        text.text = showStr;

        //颜色
        ShowColor = showColor;
        text.color = showColor;
        Debug.Log(text.color);

        PosType = posType;
        ShowTime = showTime;
        Move(posType, showTime);

    }

    private void Move(DanMuPosType postype, float showTime)
    {
        switch (posType)
        {
            case DanMuPosType.RightToLeft:
                MoveRightToLeft(showTime);
                break;

            case DanMuPosType.LeftToRight:
                MoveLeftToRight(showTime);
                break;

            case DanMuPosType.TopToBottom:
                MoveTopToBottom(showTime);
                break;

            case DanMuPosType.BottomToTop:
                MoveBottomToTop(showTime);
                break;

            case DanMuPosType.Stay:
                MoveStay(showTime);
                break;

        }


        StartCoroutine(DestorySelf());

    }

    void MoveRightToLeft(float showTime)
    {
        gameObject.transform.position = new Vector3(Screen.width + 100, Random.Range(10, Screen.height), 0);
        gameObject.transform.DOMoveX(-100, showTime);

    }

    void MoveLeftToRight(float showTime)
    {
        gameObject.transform.position = new Vector3(-100, Random.Range(10, Screen.height), 0);
        gameObject.transform.DOMoveX(Screen.width + 300, showTime);

    }

    void MoveTopToBottom(float showTime)
    {
        text.horizontalOverflow = HorizontalWrapMode.Wrap;
        text.verticalOverflow = VerticalWrapMode.Overflow;
        gameObject.transform.position = new Vector3(Random.Range(10, Screen.width - 10), Screen.height+50, 0);
        gameObject.transform.DOMoveY(-300, showTime);
    }

    void MoveBottomToTop(float showTime)
    {
        //gameObject.GetComponent<Renderer>().bounds.size.x=20;

        text.horizontalOverflow = HorizontalWrapMode.Wrap;
        text.verticalOverflow = VerticalWrapMode.Overflow;
        gameObject.transform.position = new Vector3(Random.Range(10, Screen.width-10), 0, 0);
        gameObject.transform.DOMoveY(Screen.height + 300, showTime);
    }

    void MoveStay(float showTime)
    {
        Vector3 pos = new Vector3(Random.Range(100, Screen.width - 100), Random.Range(100, Screen.height - 50), 0);
        gameObject.transform.position = pos;
    }

    IEnumerator DestorySelf()
    {

        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);

    }





}
