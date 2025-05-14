using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TavernPanel : BasePanel
{
    private ScrollRect svTavern;

    /// <summary>
    /// 管理当前物体的列表
    /// </summary>
    private List<RoleItem> roleItems = new List<RoleItem>();

    /// <summary>
    /// 当前滑动窗口内，未解锁的角色列表
    /// </summary>
    private List<RoleItem> unLockRoleItems = new List<RoleItem>();

    private Toggle togCloseCombat;
    private Toggle togArcher;
    private Toggle togWizard;
    

    public override void HideMe()
    {
        //先清楚之前的物体
        foreach (RoleItem item in roleItems)
        {
            Destroy(item.gameObject);
        }
        roleItems.Clear();
        unLockRoleItems.Clear();

        GameDataMgr.Instance.isShowTavernPanel = false;
    }

    public override void ShowMe()
    {
        ChangeType(E_RoleType.CloseCombat);

    }

    protected override void Awake()
    {
        base.Awake();
        
        svTavern = GetControl<ScrollRect>("svTavern");

        togCloseCombat = GetControl<Toggle>("togCloseCombat");
        togArcher = GetControl<Toggle>("togArcher");
        togWizard = GetControl<Toggle>("togWizard");
       
    }

    protected override void ClickBtn(string btnName)
    {
        base.ClickBtn(btnName);
        switch(btnName)
        {
            case "btnClose":
                MusicMgr.Instance.PlaySound("按钮关闭后退");
                //关闭该面板
                UIMgr.Instance.HidePanel<TavernPanel>();
                break;
            case "btnAdvertise":
                MusicMgr.Instance.PlaySound("按钮点击");
                //播放广告
                AdvertisementMgr.Instance.ShowAdv();
                break;
        }
    }

    protected override void ToggleValueChange(string toggleName, bool value)
    {
        base.ToggleValueChange(toggleName, value);

        switch(toggleName)
        {
            case "togCloseCombat":
                MusicMgr.Instance.PlaySound("按钮点击");
                if (value)
                {
                    //显示近战的物件
                    ChangeType(E_RoleType.CloseCombat);
                }
                break;
            case "togArcher":
                MusicMgr.Instance.PlaySound("按钮点击");
                if (value)
                {
                    //显示弓箭的物件
                    ChangeType(E_RoleType.Archer);
                }
                break;
            case "togWizard":
                MusicMgr.Instance.PlaySound("按钮点击");
                if (value)
                {
                    //显示魔法师的物件
                    ChangeType(E_RoleType.Wizard);
                }
                break;
            case "togSupplyTruck":
                if (value)
                {
                    //显示物资车的物件
                    ChangeType(E_RoleType.SupplyTruck);
                }
                break;
        }
    }

    

    /// <summary>
    /// 将角色物件加载到Content下
    /// </summary>
    /// <param name="lists"></param>
    private void AddItem2Content(List<T_Role> lists)
    {

        foreach (T_Role roleInfo in lists)
        {
            switch(roleInfo.f_profession)
            {
                case 1:
                    CheckIsBuy(roleInfo, GameDataMgr.Instance.closeCombatList);
                    break;        
                case 2:
                    CheckIsBuy(roleInfo, GameDataMgr.Instance.closeCombatList);
                    break;
                case 3:
                    CheckIsBuy(roleInfo, GameDataMgr.Instance.closeCombatList);
                    break;
                case 4:
                    CheckIsBuy(roleInfo, GameDataMgr.Instance.closeCombatList);
                    break;
                case 5:
                    CheckIsBuy(roleInfo, GameDataMgr.Instance.archerList);
                    break;
                case 6:
                    CheckIsBuy(roleInfo, GameDataMgr.Instance.archerList);
                    break;
                case 7:
                    CheckIsBuy(roleInfo, GameDataMgr.Instance.wizardList);
                    break;
                case 8:
                    CheckIsBuy(roleInfo, GameDataMgr.Instance.wizardList);
                    break;
                case 9:
                    CheckIsBuy(roleInfo, GameDataMgr.Instance.wizardList);
                    break;
            }
            
           
        }
    }

    /// <summary>
    /// 根据Toggle的不同而加载不同的物体
    /// </summary>
    /// <param name="roleType"></param>
    public void ChangeType(E_RoleType roleType)
    {
        //先清楚之前的物体
        foreach (RoleItem item in roleItems)
        {
            Destroy(item.gameObject);
        }
        roleItems.Clear();
        unLockRoleItems.Clear();

        switch (roleType)
        {
            case E_RoleType.CloseCombat:
                AddItem2Content(GameDataMgr.Instance.closeCombatList);
                togCloseCombat.isOn = true;
                break;
            case E_RoleType.Archer:
                AddItem2Content(GameDataMgr.Instance.archerList);
                togArcher.isOn = true;
                break;
            case E_RoleType.Wizard:
                AddItem2Content(GameDataMgr.Instance.wizardList);
                togWizard.isOn = true;
                break;            
        }
    }

    private void CheckIsBuy(T_Role role,List<T_Role> list)
    {
        int index = list.IndexOf(role) - 1;
        if (index <= 0)
            index = 0;
        if (list[index].isUnlock||role.f_id=="1_11"||role.f_id=="1_21"||role.f_id=="1_31"||role.f_id=="2_1"||role.f_id=="2_11"||role.f_id=="3_1"||role.f_id=="3_11"|| role.f_id == "3_18")
        {
            ABResMgr.Instance.LoadResAsync<GameObject>("object", "roleItem", (obj) =>
            {
                RoleItem roleItem = Instantiate(obj).GetComponent<RoleItem>();
                roleItem.transform.SetParent(svTavern.content, false);
                roleItem.InitInfo(role);
                roleItems.Add(roleItem);
            });
        }
    }

    /// <summary>
    /// 看广告随机解锁兵种
    /// </summary>
    public void RandomUnlock()
    {
        foreach (var item in roleItems)
        {
            if(!item.roleInfo.isUnlock)
                unLockRoleItems.Add(item);
        }

        RoleItem roleItem = unLockRoleItems[Random.Range(0, unLockRoleItems.Count)];
        roleItem.roleInfo.isUnlock = true;
        //对数据进行存档
        GameDataMgr.Instance.SaveRoleData();

        BuyRoleAchieve(roleItem.roleInfo);
        if (GameDataMgr.Instance.closeCombatList.Contains(roleItem.roleInfo))
        {
            UIMgr.Instance.GetPanel<TavernPanel>((panel) =>
            {
                panel.ChangeType(E_RoleType.CloseCombat);
            });
        }
        if (GameDataMgr.Instance.archerList.Contains(roleItem.roleInfo))
        {
            UIMgr.Instance.GetPanel<TavernPanel>((panel) =>
            {
                panel.ChangeType(E_RoleType.Archer);
            });
        }
        if (GameDataMgr.Instance.wizardList.Contains(roleItem.roleInfo))
        {
            UIMgr.Instance.GetPanel<TavernPanel>((panel) =>
            {
                panel.ChangeType(E_RoleType.Wizard);
            });
        }
    }

    /// <summary>
    /// 购买角色的成就
    /// </summary>
    private void BuyRoleAchieve(T_Role roleInfo)
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
