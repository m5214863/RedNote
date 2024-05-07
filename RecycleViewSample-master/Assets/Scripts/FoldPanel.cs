using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldPanel : MonoBehaviour
{
    /// <summary>
    /// /折叠菜单
    /// </summary>
    [SerializeField]
    private GameObject panelitem;//折叠页
    [SerializeField]
    private TitleItem titleItem;
    [SerializeField]
    private DataItem dataItem;

    public List<FoldData>dataList=new List<FoldData>();
    private void Start()
    {
        Create();
    }

    public void Create()
    {
        for (int i = 0; i < dataList.Count; i++)
        {
            // 创建标题
            TitleItem title = Instantiate(titleItem).GetComponent<TitleItem>();
            title.SetTitle(dataList[i].titleName);
            title.transform.SetParent(this.transform);
            title.gameObject.SetActive(true);

            // 创建子折叠面板
            GameObject panel = Instantiate(panelitem);
            panel.transform.SetParent(this.transform);
            // 260是折叠页的宽度，30DataItem的高度
            //panel.GetComponent<RectTransform>().sizeDelta = new Vector3(260, 30 * dataList[i].data.Count);
            title.SetFoldPanel(panel);
            panel.SetActive(false);

            // 创建折叠页数据
            for (int j = 0; j < dataList[i].data.Count; j++)
            {
                DataItem item = Instantiate(dataItem).GetComponent<DataItem>();
                item.transform.SetParent(panel.transform);
                item.gameObject.SetActive(true);
                item.SetInfo(dataList[i].data[j]);
            }
        }
    }
}
[System.Serializable]
public class FoldData
{
    public string titleName;
    public List<ItemData> data;
}
[System.Serializable]
public class ItemData
{
    public string userName;
}