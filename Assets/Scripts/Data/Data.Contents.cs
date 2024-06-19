using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

namespace Data
{
    //#region CreatureData
    //[System.Serializable]
    //public class CreatureData
    //{
    //    public int DataId;
    //    public string DescriptionTextID;
    //    public string PrefabLabel;
    //    public float ColliderOffsetX;
    //    public float ColliderOffsetY;
    //    public float ColliderRadius;
    //    public float MaxHp;
    //    public float UpMaxHpBonus;
    //    public float Atk;
    //    public float AtkRange;
    //    public float AtkBonus;
    //    public float MoveSpeed;
    //    public float CriRate;
    //    public float CriDamage;
    //    public string IconImage;
    //    public string SkeletonDataID;
    //    public int DefaultSkillId;
    //    public int EnvSkillId;
    //    public int SkillAId;
    //    public int SKillBId;
    //}
    //#endregion

    //#region MonsterData
    //[System.Serializable]
    //public class MonsterData : CreatureData
    //{
    //    public int DropItemId;
    //}

    //[System.Serializable]
    //public class MonsterDataLoader : ILoader<int, MonsterData>
    //{
    //    public List<MonsterData> monsters = new List<MonsterData>();

    //    public Dictionary<int, MonsterData> MakeDict()
    //    {
    //        Dictionary<int, MonsterData> dict = new Dictionary<int, MonsterData>();
    //        foreach(MonsterData monster in monsters)
    //        {
    //            dict.Add(monster.DataId, monster);
    //        }

    //        return dict;
    //    }
    //}
    //#endregion
}
