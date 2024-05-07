using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ChangeView : MonoBehaviour
{
    //public Vector3 clickPos;
    //public RectTransform  item;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        clickPos = Input.mousePosition;
    //    }

    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        float x = Input.mousePosition.x - clickPos.x;
    //        if (Mathf.Abs(x) >= 10 && x > 0)
    //        {
    //            //ÏòÓÒ
    //            SetleftOpenOrRight();
    //        }
    //        else if (Mathf.Abs(x) >= 10 && x < 0)
    //        {
    //            //Ïò×ó
    //            SetLeftOrRight();
    //        }
    //    }
    //}

    //private void SetLeftOrRight()
    //{
    //    item.transform.position -= transform.right * 0.2f;
    //  //  item.DOMoveX(2,90,false);
    //}

    //private void SetleftOpenOrRight()
    //{
    //    item.transform.position -= transform.right * 0.2f;
    //    //item.DOMoveX(2, -90, false);
    //}



    enum TouchMoveDir
    {
        idle, left, right, up, down
    }

    public class TouchTest : MonoBehaviour
    {
        public GameObject target;
        float minDis = 1;
        TouchMoveDir moveDir;

        // Use this for initialization
        void Start()
        {
            Input.multiTouchEnabled = true;
            Input.simulateMouseWithTouches = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (Input.GetTouch(0).deltaPosition.sqrMagnitude > minDis)
                {
                    Vector2 deltaDir = Input.GetTouch(0).deltaPosition;
                    if (Mathf.Abs(deltaDir.x) > Mathf.Abs(deltaDir.y))
                    {
                        moveDir = deltaDir.x > 0 ? TouchMoveDir.right : TouchMoveDir.left;
                    }
                    if (Mathf.Abs(deltaDir.y) > Mathf.Abs(deltaDir.x))
                    {
                        moveDir = deltaDir.y > 0 ? TouchMoveDir.up : TouchMoveDir.down;
                    }
                }
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                moveDir = TouchMoveDir.idle;
            }

            if (moveDir == TouchMoveDir.right)
            {
                Debug.Log("right");
                target.transform.position += transform.right * 0.2f;
            }
            if (moveDir == TouchMoveDir.left)
            {
                Debug.Log("left");
                target.transform.position -= transform.right * 0.2f;
            }
            if (moveDir == TouchMoveDir.up)
            {
                target.transform.position += transform.up * 0.2f;
            }
            if (moveDir == TouchMoveDir.down)
            {
                target.transform.position -= transform.up * 0.2f;
            }
        }
    }
}




