using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;             //命名空间
using UnityEngine.UI;

public class TitleItemCon : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]
    private Text title;         //好友类型

    public bool isFold = true;          //是否折叠状态
    public Transform foldPanel;

    public void OnPointerClick(PointerEventData eventData)
    {
        //折叠时点击，弹出显示，反之收起
        if(isFold)
        {
            isFold = false;

            if(foldPanel!=null)
            {
                foldPanel.gameObject.SetActive(true);
                foldPanel.DOScaleY(1, 0.1f);                    //弹出显示具体好友
            }
        }
        else
        {
            isFold = true;

            if(foldPanel!=null)
            {
                foldPanel.DOScaleY(0, 0.1f).OnComplete(() =>
                 {
                     foldPanel.gameObject.SetActive(false);
                 });
            }
        }
    }

    //设置好友类型标题
    public void SetTitle(string titleName)
    {
        title.text = titleName;
    }

    //设置折叠面板
    public void SetFoldPanel(GameObject panel)
    {
        foldPanel = panel.transform;
    }
}
