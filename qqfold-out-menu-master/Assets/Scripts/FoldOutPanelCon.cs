using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//折叠菜单
public class FoldOutPanelCon : MonoBehaviour
{
    [SerializeField]
    private GameObject panelItem;           //折叠页
    [SerializeField]
    private TitleItemCon titleItem;         //标题
    [SerializeField]
    private DataItemCon dataItem;           //子内容

    //折叠数据集合
    public List<FoldData> dataList = new List<FoldData>();

    private void Awake()
    {
        //准备数据（规范--读配置表）
        List<ItemData> items5  = new List<ItemData> { new ItemData("我的Android手机") };
        List<ItemData> items1 = new List<ItemData> { new ItemData("祈穆"), new ItemData("十九"), new ItemData("漏儿") };
        List<ItemData> items2 = new List<ItemData> { new ItemData("垠") };
        List<ItemData> items3 = new List<ItemData> { new ItemData("流年")};
        List<ItemData> items4 = new List<ItemData> { new ItemData("含章可贞"), new ItemData("筱梦"), new ItemData("予"),new ItemData("Sur I'amour"),new ItemData("易阵风吹致永远~"),new ItemData("万物归一者") };

        FoldData fold1 = new FoldData("我的设备", items5);
        FoldData fold3 = new FoldData("家人", items2);
        FoldData fold2 = new FoldData("朋友", items1);
        FoldData fold4 = new FoldData("室友", items4);
        FoldData fold5 = new FoldData("黑名单", items3);

        dataList.Add(fold1);
        dataList.Add(fold2);
        dataList.Add(fold3);
        dataList.Add(fold4);
        dataList.Add(fold5);
    }
    // Start is called before the first frame update
    void Start()
    {
        Create();
    }
    
    public void Create()
    {
        for(int i=0;i<dataList.Count;i++)
        {
            //创建标题
            TitleItemCon title = Instantiate(titleItem).GetComponent<TitleItemCon>();
            title.SetTitle(dataList[i].titleName);
            title.transform.SetParent(this.transform);
            title.gameObject.SetActive(true);

            //创建子折叠面板
            GameObject panel = Instantiate(panelItem);
            panel.transform.SetParent(this.transform);

            //260是折叠页的宽度   30是DataItem的高度

            title.SetFoldPanel(panel);
            panel.SetActive(false);

            //创建折叠页数据
            for(int j=0;j<dataList[i].datas.Count;j++)
            {
                DataItemCon item = Instantiate(dataItem).GetComponent<DataItemCon>();
                item.transform.SetParent(panel.transform);
                item.gameObject.SetActive(true);
                item.SetName(dataList[i].datas[j]);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
