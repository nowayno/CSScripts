using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.CSScripts
{
    class Bullet: MonoBehaviour
    {
        private float m_Hurt;//the bullet's hurt
        private int m_Count;//the bullet's cout at once
        private int m_MaxCount;//the all bullet's cout
        private float speed;
        private bool m_Special;//is the bullet special
        private M_ROLE m_role;
        public enum M_ROLE
        {
            BLUE,
            RED
        }
        public float Hurt
        {
            get
            {
                return m_Hurt;
            }

            set
            {
                m_Hurt = value;
            }
        }

        public int Count
        {
            get
            {
                return m_Count;
            }

            set
            {
                m_Count = value;
            }
        }

        public int MaxCount
        {
            get
            {
                return m_MaxCount;
            }

            set
            {
                m_MaxCount = value;
            }
        }

        public bool Special
        {
            get
            {
                return m_Special;
            }

            set
            {
                m_Special = value;
            }
        }

        public float Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        internal M_ROLE Role
        {
            get
            {
                return m_role;
            }

            set
            {
                m_role = value;
            }
        }

        public Bullet()
        {

        }

    }
}
