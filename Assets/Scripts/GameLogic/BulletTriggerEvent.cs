﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletTriggerEvent : MonoBehaviour
{
    //发射炮弹的塔
    [SerializeField]
    private Individual tower;

    //可能的炮弹添加BUFF
    public int buffID;

    //死亡产生的特效对象（该对象会自动删除）
    public GameObject dieEffect;

    private void OnTriggerEnter(Collider collison)
    {
        var collisonObject = collison.gameObject;

        //子弹打到玩家、非个体单位
        if (collison.name == "PlayerHandle" || LayerMask.LayerToName(collisonObject.layer) != "Individual")
        {
            return;
        }

        //此处应该使用tower的消息系统来发消息
        MessageSystem messageSystem = tower.GetComponent<MessageSystem>();
        Individual otherIndividual = collisonObject.GetComponent<Individual>();

        messageSystem.SendMessage(1, otherIndividual.ID,tower.attack);

        //特效对象产生
        if (dieEffect)
        GameObject.Instantiate(dieEffect, transform.position,dieEffect.transform.rotation , transform.parent);

        Destroy(gameObject);
    }

    private void OnSpecialEffect()
    {
        
    }
}
