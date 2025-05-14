using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchieveItem : BasePanel
{
    public Text txtName;
    public Text txtReward;
    public Text txtTips;
    public Button btnSure;

    private T_Achieve achieveInfo;

    

    public override void HideMe()
    {
        
    }

    public override void ShowMe()
    {
        
    }

    protected override void Awake()
    {
        base.Awake();

        btnSure.onClick.AddListener(() =>
        {
            MusicMgr.Instance.PlaySound("按钮点击");
            achieveInfo.isDone = true;
            txtTips.text = "已完成";
            //存档
            GameAchieveMgr.Instance.SaveAchieveData();

            //增加金币
            GameDataMgr.Instance.playCoin += achieveInfo.f_cjjl;
            //隐藏按钮
            btnSure.gameObject.SetActive(false);

            UIMgr.Instance.GetPanel<AchievePanel>(panel =>
            {
                panel.ClearAllItem();
                panel.AddItem2Content(GameAchieveMgr.Instance.achieveList);
            });
        });
    }

    public void InitInfo(T_Achieve achieve)
    {
        achieveInfo=achieve;
        txtName.text = achieveInfo.f_cjmc;
        txtReward.text = achieveInfo.f_cjjl.ToString();
        //根据成就系统修改tip
        ChangeTips();
    }
    
    private void ChangeTips()
    {
        if (!achieveInfo.isDone)
        {
            if (achieveInfo.f_ywccs < achieveInfo.f_cjwcsl)
                txtTips.text = achieveInfo.f_ywccs + "/" + achieveInfo.f_cjwcsl;
            else
                btnSure.gameObject.SetActive(true);
        }
        else
        {
            btnSure.gameObject.SetActive(false);
            txtTips.text = "已全部完成";
        }
    }
}
