using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//具体显示的好友名字格子
public class DataItemCon : MonoBehaviour
{
    public Text name;
    
    //设置好友名字
    public void SetName(ItemData data)
    {
        name.text = data.userName;
            
    }
}
