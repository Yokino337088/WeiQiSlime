using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : BasePanel
{
    public override void HideMe()
    {
        
    }

    public override void ShowMe()
    {
        
    }

    protected override void ClickBtn(string btnName)
    {
        base.ClickBtn(btnName);
        switch (btnName)
        {
            case "btnClose":
                MusicMgr.Instance.PlaySound("按钮关闭后退");
                //关闭该面板
                UIMgr.Instance.HidePanel<SettingPanel>();
                break;
        }
    }

    protected override void ToggleValueChange(string sliderName, bool value)
    {
        base.ToggleValueChange(sliderName, value);
        switch (sliderName)
        {
            case "togMusic":
                //当没有被选中时，关闭背景音乐
                if (value)
                    MusicMgr.Instance.PlayBKMusic("rememberMe");
                else
                    MusicMgr.Instance.StopBKMusic();
                break;
            case "togSound":
                MusicMgr.Instance.PlayOrPauseSound(value);  
                break;
        }
    }
}
