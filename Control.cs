using UnityEngine;
using System.Collections;
using Assets.CSScripts;
using System.Collections.Generic;
using System;

public class Control : MonoBehaviour
{
    public Transform m_camera;
    private Camera camera;
    private CharacterController m_ch;
    private Animator m_animator;
    private float m_cameraH = 1.4f;
    private Vector3 m_cameraEu;
    private float m_gravity = 5;

    public void setPlayer(Transform m_trans, string preName)
    {
        m_ch = m_trans.GetComponent<CharacterController>();
        //m_camera = Camera.main.transform;
        camera = m_camera.GetComponent<Camera>();
        Vector3 pos = m_trans.position;
        pos.y += m_cameraH;
        m_camera.position = pos;
        m_camera.rotation = m_trans.rotation;
        m_cameraEu = m_trans.eulerAngles;
    }
    public void ChaControl(Transform m_trans, float speed)
    {
        m_animator = m_trans.GetComponent<Animator>();
        AnimatorStateInfo aniinfo = m_animator.GetCurrentAnimatorStateInfo(0);
        float x = 0, y = 0, z = 0;
        //移动方法
        Move(m_trans, speed, aniinfo, x, y, z);
        //鼠标移动
        float mouse_x = Input.GetAxis("Mouse X");
        float mouse_y = Input.GetAxis("Mouse Y");
        //镜头移动
        Euler(m_trans, mouse_y, mouse_x);
        //netplayer.sendSomeData();
    }
    private void Move(Transform m_trans, float speed, AnimatorStateInfo aniinfo, float x, float y, float z)
    {

        float time = Time.deltaTime;
        y -= m_gravity * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift))
            time *= 2;
        if (Input.GetAxis("Horizontal") > 0)
        {
            x += time * speed;
            if (aniinfo.IsName("Base Layer.Idle"))
            {
                m_animator.SetBool("idle", false);
                m_animator.SetBool("run", true);
            }
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            x -= time * speed;
            if (aniinfo.IsName("Base Layer.Idle"))
            {
                m_animator.SetBool("idle", false);
                m_animator.SetBool("run", true);
            }
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            z += time * speed;
            if (aniinfo.IsName("Base Layer.Idle") && !m_animator.IsInTransition(0))
            {
                m_animator.SetBool("idle", false);
                m_animator.SetBool("run", true);
            }
        }
        else if (Input.GetAxis("Vertical") < 0)
            z -= time * speed;

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            if (aniinfo.IsName("Base Layer.Run") && !m_animator.IsInTransition(0))
            {
                m_animator.SetBool("run", false);
                m_animator.SetBool("idle", true);
            }
        }
        // netplayer.sendSomeData("Position:" + x + "," + y + "," + z);
        m_ch.Move(m_trans.TransformDirection(new Vector3(x, y, z)));
    }
    private void Euler(Transform m_trans, float mouse_y, float mouse_x)
    {
        m_cameraEu.x -= mouse_y;
        m_cameraEu.y += mouse_x;
        m_camera.eulerAngles = m_cameraEu;

        Vector3 camero = m_camera.eulerAngles;
        camero.x = 0; camero.z = 0;
        m_trans.eulerAngles = camero;

        Vector3 pos = m_trans.position;
        pos.y += m_cameraH;
        m_camera.position = pos;
        //netplayer.sendSomeData("Rotation:" + mouse_y + "," + mouse_x);
    }
    public void NetEular(Transform m_trans, float mouse_y, float mouse_x)
    {
        Euler(m_trans, mouse_y, mouse_x);
    }
    public void ShootBullet(Transform m_trans, Transform m_bullet, bool isShoot = true)
    {
        
        if (isShoot)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;
            bool hit = Physics.Raycast(ray, out info);
            if (hit)
            {
                Vector3 point = info.point;
                m_trans.LookAt(point);
                // Debug.Log(point);
                // Debug.DrawLine(ray.origin, point, Color.red);
                float x = Mathf.Abs(point.x);
                float y = Mathf.Abs(point.y);
                float z = Mathf.Abs(point.z);
            }
        }
        else
        { }
    }

    public void Jump(Transform m_trans, float jumpTime)
    {
        m_trans.Translate(new Vector3(0, jumpTime, 0));
    }
}
