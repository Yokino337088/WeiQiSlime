using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPanel : BasePanel
{
    public Text txtTips;

    public Text txtCantBuy;

    private T_Role roleInfo;

    public override void HideMe()
    {
        txtCantBuy.gameObject.SetActive(false);
    }

    public override void ShowMe()
    {
        Invoke(nameof(DelayCheckIsBuy), 0.1f);
    }


    protected override void Awake()
    {
        base.Awake();
        txtCantBuy.gameObject.SetActive(false);

    }

    protected override void ClickBtn(string btnName)
    {
        base.ClickBtn(btnName);

        switch (btnName)
        {
            case "btnSure":
                MusicMgr.Instance.PlaySound("按钮点击");
                if (roleInfo.isUnlock)
                {
                    UIMgr.Instance.HidePanel<BuyPanel>();
                }
                else
                {
                    if (GameDataMgr.Instance.playCoin >= roleInfo.f_exp * 10*roleInfo.f_level)
                    {
                        roleInfo.isUnlock = true;
                        //减少金币
                        GameDataMgr.Instance.playCoin -= roleInfo.f_exp * 10 * roleInfo.f_level;
                        //修改玩家金币的UI逻辑
                        UIMgr.Instance.GetPanel<BeginPanel>((panel) =>
                        {
                            panel.ChangeCoinNum(GameDataMgr.Instance.playCoin);
                        });
                        //对数据进行存档
                        GameDataMgr.Instance.SaveRoleData();
                        txtCantBuy.text = "购买成功";
                        txtCantBuy.gameObject.SetActive(true);
                        Invoke(nameof(DelayHidePanel), 1f);
                        //更新成就系统
                        BuyRoleAchieve();
                        if (GameDataMgr.Instance.closeCombatList.Contains(roleInfo))
                        {
                            UIMgr.Instance.GetPanel<TavernPanel>((panel) =>
                            {
                                panel.ChangeType(E_RoleType.CloseCombat);
                            });
                        }
                        if (GameDataMgr.Instance.archerList.Contains(roleInfo))
                        {
                            UIMgr.Instance.GetPanel<TavernPanel>((panel) =>
                            {
                                panel.ChangeType(E_RoleType.Archer);
                            });
                        }
                        if (GameDataMgr.Instance.wizardList.Contains(roleInfo))
                        {
                            UIMgr.Instance.GetPanel<TavernPanel>((panel) =>
                            {
                                panel.ChangeType(E_RoleType.Wizard);
                            });
                        }
                    }
                    
                    else
                    {
                        txtCantBuy.text = "金币不足!";
                        txtCantBuy.gameObject.SetActive(true);
                        Invoke(nameof(HideTips), 0.5f);
                    }
                }
                    break;
                
            case "btnClose":
                MusicMgr.Instance.PlaySound("按钮关闭后退");
                UIMgr.Instance.HidePanel<BuyPanel>();
                break;
        }
    }

    public void ChangeTips(int price, string name)
    {
        txtTips.text = "确定花费" + price + "金币购买" + name + "吗?";
    }

    public void SetRoleInfo(T_Role role)
    {
        roleInfo = role;
    }

    private void HideTips()
    {
        txtCantBuy.gameObject.SetActive(false);
    }

    private void DelayHidePanel()
    {
        UIMgr.Instance.HidePanel<BuyPanel>();
    }

    private void DelayCheckIsBuy()
    {
        if (roleInfo.isUnlock)
        {
            txtTips.gameObject.SetActive(false);

            txtCantBuy.text = "已经解锁该角色!";
            txtCantBuy.gameObject.SetActive(true);
        }
        else
        {
            txtTips.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 购买角色的成就
    /// </summary>
    private void BuyRoleAchieve()
    {
        switch (roleInfo.f_level)
        {
            case 2:
                GameAchieveMgr.Instance.CompleteAchievement(6, 0);
                break;
            case 3:
                GameAchieveMgr.Instance.CompleteAchievement(6, 1);
                break;
            case 4:
                GameAchieveMgr.Instance.CompleteAchievement(6, 2);
                break;
            case 5:
                GameAchieveMgr.Instance.CompleteAchievement(6, 3);
                break;
            case 6:
                GameAchieveMgr.Instance.CompleteAchievement(6, 4);
                break;
            case 7:
                GameAchieveMgr.Instance.CompleteAchievement(6, 5);
                break;
        }
    }
}
