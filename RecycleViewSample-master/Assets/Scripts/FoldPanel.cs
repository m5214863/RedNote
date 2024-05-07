using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldPanel : MonoBehaviour
{
    /// <summary>
    /// /�۵��˵�
    /// </summary>
    [SerializeField]
    private GameObject panelitem;//�۵�ҳ
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
            // ��������
            TitleItem title = Instantiate(titleItem).GetComponent<TitleItem>();
            title.SetTitle(dataList[i].titleName);
            title.transform.SetParent(this.transform);
            title.gameObject.SetActive(true);

            // �������۵����
            GameObject panel = Instantiate(panelitem);
            panel.transform.SetParent(this.transform);
            // 260���۵�ҳ�Ŀ��ȣ�30DataItem�ĸ߶�
            //panel.GetComponent<RectTransform>().sizeDelta = new Vector3(260, 30 * dataList[i].data.Count);
            title.SetFoldPanel(panel);
            panel.SetActive(false);

            // �����۵�ҳ����
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