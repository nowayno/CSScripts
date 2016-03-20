using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.CSScripts
{
    class GlobalClass : MonoBehaviour
    {
        public static GlobalClass Instanse;
        private int score;
        private int bulletCount;
        private int nowCount;
        public enum NETPLAYER
        {
            ISNET,
            NOTNET
        }
        public NETPLAYER netp;
        public GlobalClass()
        {
            netp = NETPLAYER.NOTNET;
        }

        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

        void Start()
        {
            Instanse = this;
        }

        void OnGUI()
        {
            GUI.skin.label.fontSize = 30;
            //GUI.skin.label.fontStyle = FontStyle.Bold;
            GUI.Label(new Rect(Screen.width / 2, 10, 100, 100), "分数:" + score);
            GUI.Label(new Rect(10, Screen.height - 100, 170, 100), "弹容量:" + nowCount + "/" + bulletCount);
        }

        public void AddScore(int s)
        {
            score += s;
        }
        public void AddbulletCount(int count)
        {
            bulletCount = count;
        }
        public void nowBulletCount(int count)
        {
            nowCount = count;
        }
    }
}
