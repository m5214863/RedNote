using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//折叠数据
public class FoldData
{
    public string titleName;
    public List<ItemData> datas;

    public FoldData(string titleName, List<ItemData> datas)
    {
        this.titleName = titleName;
        this.datas = datas;
    }
}


//具体显示名字的每一格数据
public class ItemData
{
    public string userName;

    public ItemData(string userName)
    {
        this.userName = userName;
    }
}