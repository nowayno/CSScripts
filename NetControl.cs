using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.CSScripts;
using System;

public class NetControl : MonoBehaviour
{
    private Transform m_trans;
    private CharacterController m_ch;
    private NetPlayer netplayer;
    private Control control;
    private GlobalClass global;

    public void Start()
    {
        m_trans = transform;
        m_ch = m_trans.GetComponent<CharacterController>();
        netplayer = new NetPlayer();
        global = new GlobalClass();
    }
    public void Update()
    {
        if (global.netp == GlobalClass.NETPLAYER.NOTNET)
        {
            netplayer.sendSomeData("Position:" + m_trans.position.x + "," + m_trans.position.y + "," + m_trans.position.z);
            netplayer.sendSomeData("Rotation:" + m_trans.rotation.x + "," + m_trans.rotation.y);
        }
        else
        {
            Dictionary<string, float> dic = netplayer.reciveSomeData();
            if (dic.ContainsKey("What"))
            {
                float one = dic["What"];
                switch (Convert.ToInt16(one))
                {
                    case 0:
                        break;
                    case 1:
                        m_ch.Move(m_trans.TransformDirection(new Vector3(dic["p_x"], dic["p_y"], dic["p_z"])));
                        //NetMove(m_trans, speed, aniinfo, dic["p_x"], dic["p_y"], dic["p_z"]);
                        break;
                    case 2:
                        control.NetEular(m_trans, dic["mouse_y"], dic["mouse_x"]);
                        break;
                    case 3:
                        //ShootBullet();
                        break;
                    case 4:
                        transform.tag = "Dead";
                        break;
                    case -1:
                        break;
                }
            }
        }
    }
}
