using UnityEngine;
using System.Collections;
using Assets.CSScripts;

public class IceBullet : MonoBehaviour
{
    public ParticleSystem fireExp;
    Bullet bullet;
    void Awake()
    {
        bullet = GetComponent<Bullet>();
    }
    // Use this for initialization
    void Start()
    {
        setBullet();
        Destroy(gameObject, 5.0f);
    }
    /// <summary>
    /// 设置子弹属性
    /// </summary>
    void setBullet()
    {
        bullet.Hurt = 10;
        bullet.Speed = 20;
        bullet.Count = 5;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, bullet.Speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.CompareTo(tag == "Blue" ? "Red" : "Blude") == 0)
        {
            Player player = collider.GetComponent<Player>();
            player.Blood -= bullet.Hurt;
            //Instantiate(fireExp,collider.ClosestPointOnBounds(transform.position),Quaternion.identity);
            Destroy(gameObject);
            if (player.Blood <= 0)
            {
                GlobalClass.Instanse.AddScore(1);
                collider.tag = "Dead";
            }
        }
        else
        {
            Instantiate(fireExp, collider.ClosestPointOnBounds(transform.position), Quaternion.identity);
            Destroy(gameObject);
            //Destroy(fireExp, 2);
        }
    }
}
