using UnityEngine;
using System.Collections;
using Assets.CSScripts;
using System;
using System.Threading;
using System.Collections.Generic;

public class FirePlayerScript : MonoBehaviour
{
    public Transform m_bullet;
    public Transform m_shoot;
    public Texture mouseTexture;
    public Transform enviro;
    public bool isShooting;
    private Transform m_trans;
    private float shootIimer = 0.2f;
    private float jumpTime = 3;
    private bool isJump = false;
    private int bulletCount;
    private int bulletMaxcount;
    Player fireplayer;
    Control control;
    //FireBullet bullet;

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
        fireplayer = GetComponent<Player>();
        control = GetComponent<Control>();
        //bullet = m_bullet.GetComponent<FireBullet>();
    }
    void Start()
    {
        bulletCount = 5;
        bulletMaxcount = 5;
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
        fireplayer.Blood = 140;
        fireplayer.Defend = 0;
        fireplayer.IsDead = false;
        fireplayer.Score = 0;
        fireplayer.Speed = 3;
        fireplayer.Tag = tag;
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
            tag = fireplayer.Tag;
        shootIimer -= Time.deltaTime;
        control.ChaControl(m_trans, fireplayer.Speed);

        if (Input.GetMouseButton(0))
        {
            if (m_trans.tag == "Dead")
                return;
            //子弹数目控制，如果少于0就要等待才能继续发射
            if (bulletCount > 0)
            {
                if (shootIimer <= 0)
                {
                    shootIimer = 0.2f;
                    control.ShootBullet(m_shoot, m_bullet);
                    Transform firebullet = Instantiate(m_bullet, m_shoot.position, m_shoot.rotation) as Transform;
                    firebullet.tag = m_trans.tag;
                    bulletCount -= 1;
                }
            }
            else
            {
                bulletCount = bulletMaxcount;
                shootIimer = 4;
            }
        }
        //如果脚部坐标的y轴和环境的y轴差绝对值小于0.2，则可以跳跃
        if (Input.GetAxis("Jump") > 0 && (Mathf.Abs(m_trans.position.y - enviro.position.y) < 0.2f))
            isJump = true;
    }
    void FixedUpdate()
    {
        if (isJump)
        {
            control.Jump(m_trans, jumpTime);
            isJump = false;
        }
    }
    void OnGUI()
    {
        Vector3 po = Input.mousePosition;
        GUI.DrawTexture(new Rect(po.x - mouseTexture.width / 2, Screen.height - po.y, mouseTexture.width, mouseTexture.height), mouseTexture);
    }
}
