using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.CSScripts
{
    class Player : MonoBehaviour
    {
        private float m_Blood;//the player's blood
        private float m_Defend;//the playr's defend
        private int m_Score;//the player's score
        private float m_speed;
        private string m_tag;
        //what's role the player playing
        public enum M_ROLE
        {
            BLUE,
            RED
        }
        //what's the oline role player playing
        public enum M_NETROLE
        {
            NETROLE,
            NOTROLE
        }
        private M_ROLE m_role;
        private M_NETROLE m_netrole;
        #region also for NET
        //the player's position
        private float m_Position_x;
        private float m_Position_y;
        private float m_Position_z;
        //the player's rotation
        private float m_Rotation_x;
        private float m_Rotation_y;
        private float m_Rotation_z;
        //the player's shooting position
        private float m_ShootPoint_x;
        private float m_ShootPoint_y;
        private float m_ShootPoint_z;
        //did the player dead
        private bool m_IsDead;
        #endregion
        #region also for net
        public float Position_x
        {
            get
            {
                return m_Position_x;
            }

            set
            {
                m_Position_x = value;
            }
        }

        public float Position_y
        {
            get
            {
                return m_Position_y;
            }

            set
            {
                m_Position_y = value;
            }
        }

        public float Position_z
        {
            get
            {
                return m_Position_z;
            }

            set
            {
                m_Position_z = value;
            }
        }

        public float Rotation_x
        {
            get
            {
                return m_Rotation_x;
            }

            set
            {
                m_Rotation_x = value;
            }
        }

        public float Rotation_y
        {
            get
            {
                return m_Rotation_y;
            }

            set
            {
                m_Rotation_y = value;
            }
        }

        public float Rotation_z
        {
            get
            {
                return m_Rotation_z;
            }

            set
            {
                m_Rotation_z = value;
            }
        }

        public float ShootPoint_x
        {
            get
            {
                return m_ShootPoint_x;
            }

            set
            {
                m_ShootPoint_x = value;
            }
        }

        public float ShootPoint_y
        {
            get
            {
                return m_ShootPoint_y;
            }

            set
            {
                m_ShootPoint_y = value;
            }
        }

        public float ShootPoint_z
        {
            get
            {
                return m_ShootPoint_z;
            }

            set
            {
                m_ShootPoint_z = value;
            }
        }

        public bool IsDead
        {
            get
            {
                return m_IsDead;
            }

            set
            {
                m_IsDead = value;
            }
        }
        #endregion
        public float Blood
        {
            get
            {
                return m_Blood;
            }

            set
            {
                m_Blood = value;
            }
        }

        public float Defend
        {
            get
            {
                return m_Defend;
            }

            set
            {
                m_Defend = value;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public M_ROLE Role
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

        public M_NETROLE Netrole
        {
            get
            {
                return m_netrole;
            }

            set
            {
                m_netrole = value;
            }
        }

        public float Speed
        {
            get
            {
                return m_speed;
            }

            set
            {
                m_speed = value;
            }
        }

        public string Tag
        {
            get
            {
                return m_tag;
            }

            set
            {
                m_tag = value;
            }
        }

        public static Player Instance;
        public Player() { Instance = this; }
        public Player(float blood, float defend, int score)
        {
            m_Blood = blood;
            m_Defend = defend;
            m_Score = score;
        }
    }
}