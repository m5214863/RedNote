using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuseEventCon : MonoBehaviour
{
    Image image;
    private Vector2 first = Vector2.zero;
    private Vector2 second = Vector2.zero;
    bool isLeft = false;
    bool isRight = false;
    // 鼠标左右滑动事件
    void OnGUI()

    {
        if (Event.current.type == EventType.MouseDown)

        {
            //记录鼠标按下的位置 　　

            first = Event.current.mousePosition;

        }

        if (Event.current.type == EventType.MouseDrag)

        {
            //记录鼠标拖动的位置 　　

            second = Event.current.mousePosition;

            if (second.x < first.x)

            {
                //拖动的位置的x坐标比按下的位置的x坐标小时,响应向左事件 　　

                print("left");
                image.GetComponent<Image>().sprite = Instantiate(Resources.Load<Sprite>("1"));
            }

            if (second.x > first.x)

            {
                //拖动的位置的x坐标比按下的位置的x坐标大时,响应向右事件 　　

                print("right");
                image.GetComponent<Image>().sprite = Instantiate(Resources.Load<Sprite>("2"));
            }

            first = second;

        }

    }
    enum slideVector { nullVector, left, right };
    private Vector2 lastPos;//上一个位置
    private Vector2 currentPos;//下一个位置
    private slideVector currentVector = slideVector.nullVector;//当前滑动方向
    private float timer;//时间计数器
    public float offsetTime = 0.01f;//判断的时间间隔
    private void Awake()
    {
        image=GetComponent<Image>();
    }

    private void Update()
    {
        //触摸左右滑动事件
        if (Input.touchCount == 1)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                lastPos = Input.touches[0].position;
                currentPos = Input.touches[0].position;
                timer = 0;
                Debug.Log("Click begin && Drag begin");
                
            }
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                currentPos = Input.touches[0].position;
                timer += Time.deltaTime;
                if (timer > offsetTime)
                {
                    if (currentPos.x < lastPos.x)
                    {
                        if (currentVector == slideVector.left)
                        {
                            return;
                        }
                        //TODO trun Left event
                        currentVector = slideVector.left;
                        Debug.Log("Touch Turn left");

                    }
                    if (currentPos.x > lastPos.x)
                    {
                        if (currentVector == slideVector.right)
                        {
                            return;
                        }
                        //TODO trun right event
                        currentVector = slideVector.right;
                        Debug.Log("Touch Turn right");

                    }
                    lastPos = currentPos;
                    timer = 0;
                }
            }
            if (Input.touches[0].phase == TouchPhase.Ended)
            {//滑动结束
                currentVector = slideVector.nullVector;
                Debug.Log("Click over && Drag over");
            }
        }
    }
}