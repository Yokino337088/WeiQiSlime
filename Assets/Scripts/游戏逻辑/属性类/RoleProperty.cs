using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoleProperty
{
    /// <summary>
    /// 角色ID
    /// </summary>
    public string f_id;
    /// <summary>
    /// 角色名
    /// </summary>
    public string f_name;
    /// <summary>
    /// 角色等级
    /// </summary>
    public int f_level;
    /// <summary>
    /// 头像
    /// </summary>
    public string f_icon;
    /// <summary>
    /// 解锁价格
    /// </summary>
    public int f_exp;
    /// <summary>
    /// 种族
    /// </summary>
    public int f_zhongzu;
    /// <summary>
    /// 职业
    /// </summary>
    public int f_profession;
    /// <summary>
    /// 技能类型
    /// </summary>
    public int f_mp;
    /// <summary>
    /// 移动力
    /// </summary>
    public int f_move;
    /// <summary>
    /// 技能间隔
    /// </summary>
    public float f_atkInterval;
    /// <summary>
    /// 攻击力
    /// </summary>
    public float f_atk;
    /// <summary>
    /// 防御
    /// </summary>
    public int f_defense;
    /// <summary>
    /// 生命
    /// </summary>
    public int f_hp;
    /// <summary>
    /// 范围技能
    /// </summary>
    public int f_mp_er;
    /// <summary>
    /// 防御削弱
    /// </summary>
    public int f_mp_san;
    /// <summary>
    /// 单体治疗
    /// </summary>
    public int f_mp_si;
    /// <summary>
    /// 群体治疗
    /// </summary>
    public int f_mp_wu;
    /// <summary>
    /// 攻击距离
    /// </summary>
    public int f_block;

    /// <summary>
    /// 技能文字
    /// </summary>
    public string f_jnwz;

    /// <summary>
    /// 文字颜色
    /// </summary>
    public string f_jnwzys;

    public void SetData(T_Role role)
    {
        T_Role roleInfo = role;

        f_id = roleInfo.f_id;
        f_name = roleInfo.f_name;
        f_level = roleInfo.f_level;
        f_icon = roleInfo.f_icon;
        f_exp = roleInfo.f_exp;
        f_zhongzu = roleInfo.f_zhongzu;
        f_profession = roleInfo.f_profession;
        f_mp = roleInfo.f_mp;
        f_move = roleInfo.f_move;
        f_atkInterval = roleInfo.f_atkInterval;
        f_atk = roleInfo.f_atk;
        f_defense = roleInfo.f_defense;
        f_hp = roleInfo.f_hp;
        f_mp_er = roleInfo.f_mp_er;
        f_mp_san = roleInfo.f_mp_san;
        f_mp_si = roleInfo.f_mp_si;
        f_mp_wu = roleInfo.f_mp_wu;
        f_block = roleInfo.f_block;
        f_jnwz = roleInfo.f_jnwz;
        f_jnwzys=roleInfo.f_jnwzys;
    }
}
