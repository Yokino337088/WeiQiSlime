using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AchievePanel : BasePanel
{
    public ScrollRect svAchieve;

    private List<AchieveItem> achieveItems = new List<AchieveItem>();

    public override void HideMe()
    {
        ClearAllItem();
    }

    public override void ShowMe()
    {
        GameAchieveMgr.Instance.LoadAchieveData();
        AddItem2Content(GameAchieveMgr.Instance.achieveList);
    }

    protected override void Awake()
    {
        base.Awake();

        
    }

    protected override void ClickBtn(string btnName)
    {
        base.ClickBtn(btnName);
        switch (btnName)
        {
            case "btnClose":
                MusicMgr.Instance.PlaySound("按钮关闭后退");
                UIMgr.Instance.HidePanel<AchievePanel>();
                break;
        }
    }

    /// <summary>
    /// 将角色物件加载到Content下
    /// </summary>
    /// <param name="lists"></param>
    public void AddItem2Content(List<T_Achieve> lists)
    {
        foreach (T_Achieve roleInfo in lists)
        {
            CheckisDone(roleInfo);
        }
    }

    public void ClearAllItem()
    {
        //清空所有的物件
        foreach (var item in achieveItems)
        {
            Destroy(item.gameObject);
        }
        achieveItems.Clear();
    }

    private void CheckisDone(T_Achieve info)
    {
        int index = GameAchieveMgr.Instance.achieveList.IndexOf(info) - 1;
        if (index <= 0)
            index = 0;
        if (GameAchieveMgr.Instance.achieveList[index].isDone||info.f_cjid=="1_0"|| info.f_cjid == "2_0"|| info.f_cjid == "3_0"|| info.f_cjid == "4_0"|| info.f_cjid == "5_0"|| info.f_cjid == "6_0"|| info.f_cjid == "7_0")
        {
            ABResMgr.Instance.LoadResAsync<GameObject>("object", "achieveItem", (obj) =>
            {
                AchieveItem achieveItem = Instantiate(obj).GetComponent<AchieveItem>();
                achieveItem.transform.SetParent(svAchieve.content, false);
                achieveItem.InitInfo(info);
                achieveItems.Add(achieveItem);
            });
        }
    }
}
