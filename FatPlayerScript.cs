﻿using UnityEngine;
using System.Collections;
using Assets.CSScripts;
using System;
using System.Threading;
using System.Collections.Generic;

public class FatePlayerScript : MonoBehaviour
{
    public Transform m_bullet;
    public Transform m_shoot;
    public Texture mouseTexture;
    public bool isShooting;
    private Transform m_trans;
    private float shootIimer = 0.2f;

    Player fateplayer;
    Control control;
    //Bullet bullet;

    //internal FirePlayer Fireplayer
    //{
    //    get
    //    {
    //        return fireplayer;
    //    }

    //    set
    //    {
    //        fireplayer = value;
    //    }
    //}

    // Use this for initialization
    void Awake()
    {
        fateplayer = GetComponent<Player>();
        control = GetComponent<Control>();
        //bullet = GetComponent<Bullet>();
    }
    void Start()
    {
        setPlayer();
        //setBullet();
        isShooting = false;
        m_trans = transform;
        control.setPlayer(m_trans, PlayerName.fire);
        Cursor.lockState = CursorLockMode.Locked;
    }
    /// <summary>
    /// 设置玩家属性
    /// </summary>
    void setPlayer()
    {
        fateplayer.Blood = 200;
        fateplayer.Defend = 0;
        fateplayer.IsDead = false;
        fateplayer.Score = 0;
        fateplayer.Speed = 2;
        fateplayer.Tag = tag;
    }

    /// <summary>
    /// 设置子弹属性
    /// </summary>
    //void setBullet()
    //{
    //    bullet.Hurt = 10;
    //    bullet.Speed = 20;
    //    bullet.Count = 5;
    //}

    // Update is called once per frame
    void Update()
    {
        if (tag == "Dead")
        {
            DestroyObject(gameObject, 2);
            tag = "Idle";
            return;
        }
        if (tag == "Idle")
            tag = fateplayer.Tag;
        shootIimer -= Time.deltaTime;
        control.ChaControl(m_trans, fateplayer.Speed);

        if (Input.GetMouseButton(0))
        {
            if (m_trans.tag == "Dead")
                return;
            if (shootIimer <= 0)
            {
                shootIimer = 0.2f;
                control.ShootBullet(m_shoot, m_bullet);
                Transform firebullet = Instantiate(m_bullet, m_shoot.position, m_shoot.rotation) as Transform;
                firebullet.tag = m_trans.tag;
            }
        }
    }
    void OnGUI()
    {
        Vector3 po = Input.mousePosition;
        GUI.DrawTexture(new Rect(po.x - mouseTexture.width / 2, Screen.height - po.y, mouseTexture.width, mouseTexture.height), mouseTexture);
    }
}
