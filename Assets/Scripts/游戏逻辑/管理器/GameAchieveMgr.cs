using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAchieveMgr : SingletonAutoMono<GameAchieveMgr>
{
    //成就数据列表
    public List<T_Achieve> achieveList = new List<T_Achieve>();

    /// <summary>
    /// 击杀的敌人数量
    /// </summary>
    public int enemyCount;

    //读取成就数据
    public void LoadAchieveInfo()
    {
        Dictionary<string, T_Achieve> achieveDic = BinaryDataMgr.Instance.GetTable<T_AchieveContainer>().dataDic;

        foreach (var key in achieveDic.Keys)
        {
            achieveList.Add(achieveDic[key]);
        }
    }

    /// <summary>
    /// 储存成就数据
    /// </summary>
    public void SaveAchieveData()
    {
        BinaryDataMgr.Instance.Save(achieveList, "achieveList");
    }

    /// <summary>
    /// 读档
    /// </summary>
    public void LoadAchieveData()
    {        
        if (BinaryDataMgr.Instance.Load<List<T_Achieve>>("achieveList") != null)
        {
            achieveList = BinaryDataMgr.Instance.Load<List<T_Achieve>>("achieveList");
        }
    }



    /// <summary>
    /// 完成通关的成就
    /// </summary>
    public void CompleteAchievement(params int[] ints)
    {
        foreach (var achieveInfo in achieveList)
        {
            if (achieveInfo.f_cjid == ints[0] + "_" + ints[1] && !achieveInfo.isDone)
            {
                //已完成次数加1
                achieveInfo.f_ywccs++;
                if (achieveInfo.f_ywccs >= achieveInfo.f_cjwcsl)
                {
                    achieveInfo.f_ywccs = achieveInfo.f_cjwcsl;                  
                }
                //存档
                SaveAchieveData();
                //直接返回
                return;
            }
        }
    }

    /// <summary>
    /// 重载-根据成就id
    /// </summary>
    /// <param name="id"></param>
    public void CompleteAchievement(string id)
    {
        foreach (var achieveInfo in achieveList)
        {
            if (achieveInfo.f_cjid == id && !achieveInfo.isDone)
            {
                //已完成次数加1
                achieveInfo.f_ywccs++;
                if (achieveInfo.f_ywccs >= achieveInfo.f_cjwcsl)
                {
                    achieveInfo.f_ywccs = achieveInfo.f_cjwcsl;
                }
                //存档
                SaveAchieveData();
                //直接返回
                return;
            }
        }
    }

    /// <summary>
    /// 重载-根据成就类型
    /// </summary>
    /// <param name="id"></param>
    public void CompleteAchievement(int type)
    {
        foreach (var achieveInfo in achieveList)
        {
            if (achieveInfo.f_f_cjlx == type && !achieveInfo.isDone)
            {
                //已完成次数加1
                achieveInfo.f_ywccs++;
                if (achieveInfo.f_ywccs >= achieveInfo.f_cjwcsl)
                {
                    achieveInfo.f_ywccs = achieveInfo.f_cjwcsl;
                }
            }  
        }
        //存档
        //SaveAchieveData();
    }
}
