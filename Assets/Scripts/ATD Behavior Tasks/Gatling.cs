﻿using BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject;
using System.Collections;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("机枪塔的攻击行为")]
    [TaskCategory("Tower Attack Model")]
    [TaskIcon("Assets/Behavior Designer Movement/Editor/Icons/{SkinColor}gatlingIcon.png")]
    public class Gatling : Action
    {
        public SharedTransform target;
        public GameObject bullet;
        public GameObject bulletPoint;
        public float bulletSpeed;
        public float attackRate;
        
        IEnumerator Attack()
        {
            if (target.Value.tag == "Enemy")
            {
                GameObject bulletObj = GameObject.Instantiate(bullet,
                    bulletPoint.transform.position, Quaternion.identity);
                Vector3 fireDirection = bulletPoint.transform.position - target.Value.position;
                bulletObj.GetComponent<Rigidbody>().velocity = transform.TransformDirection
                    (fireDirection * bulletSpeed);
            }
            
            yield return new WaitForSeconds(attackRate);
        }

        public override void OnStart()
        {
            //StartCoroutine(Attack());
        }
        public override TaskStatus OnUpdate()
        {
            if (target.Value == null)
            {
                return TaskStatus.Failure;
            }
            if (target.Value.tag == "Enemy")
            {
                GameObject bulletObj = GameObject.Instantiate(bullet,
                    bulletPoint.transform.position, Quaternion.identity);
                Vector3 fireDirection = target.Value.position - bulletPoint.transform.position;
                bulletObj.GetComponent<Rigidbody>().velocity = transform.TransformDirection
                    (fireDirection * bulletSpeed);
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }
    }
}

