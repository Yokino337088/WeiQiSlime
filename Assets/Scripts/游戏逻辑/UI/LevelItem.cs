using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelItem : BasePanel
{
    public Text txtName;
    public Image imgBK;

    public Sprite spriteSelect;
    public Sprite spriteSource;

    private T_Level levelInfo;

    public override void HideMe()
    {
        
    }

    public override void ShowMe()
    {
        
    }

    public void InitInfo(T_Level info)
    {
        txtName.text = info.f_gkname;
        levelInfo = info;
    }

    public void ClickIcon(BaseEventData data)
    {
        MusicMgr.Instance.PlaySound("按钮点击");
        //如果再次点击，那就更新选中状态
        if (GameLevelMgr.Instance.nowSelectItem != null && GameLevelMgr.Instance.nowSelectItem != this)
        {
            GameLevelMgr.Instance.nowSelectItem.imgBK.sprite = spriteSource;

            GameLevelMgr.Instance.nowLevelInfo = null;
            GameLevelMgr.Instance.nowSelectItem = null;
           
        }

        GameLevelMgr.Instance.nowLevelInfo = levelInfo;
        GameLevelMgr.Instance.nowSelectItem = this;

        imgBK.sprite=spriteSelect;

        UIMgr.Instance.GetPanel<ChooseLevelPanel>(panel =>
        {
            panel.ChangeTips(levelInfo);
        });
    }
}
