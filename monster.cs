using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{ 
    public enum Status { idle, chase };
    public Status status;
    private Transform monster_transform , player_transform;
    public float speed;
    public float vision;
    private SpriteRenderer spr;
    public enum Face { Left,Right};
    public Face face;
    // Start is called before the first frame update
    void Start()
    {
        monster_transform = this.transform;
        player_transform = GameObject.Find("player").transform;
        spr = this.transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        if (player_transform)
        {
            float distantx = Mathf.Abs(monster_transform.position.x - player_transform.position.x);
            float distanty = Mathf.Abs(monster_transform.position.y - player_transform.position.y);
            if ((distantx <= vision && distantx >= 0.5)||(distanty <= vision && distanty >= 0.5))
            {
                status = Status.chase;
            }
            else
            {
                status = Status.idle;
            }
        }
        switch (status)
        {
            case Status.idle:
                break;
            case Status.chase:
                if (player_transform)
                {
                    if (monster_transform.position.x >= player_transform.position.x)
                    {
                        spr.flipX = true;
                        face = Face.Left;
                    }
                    else
                    {
                        spr.flipX = false;
                        face = Face.Right;
                    }
                }
                switch (face)
                {
                    case Face.Left:
                        monster_transform.position -= new Vector3(speed * deltaTime, 0, 0);
                        break;
                    case Face.Right:
                        monster_transform.position += new Vector3(speed * deltaTime, 0, 0);
                        break;
                }
                if(monster_transform.position.y >= player_transform.position.y)
                {
                    monster_transform.position -= new Vector3(0, speed * deltaTime, 0);
                }
                else
                    monster_transform.position += new Vector3(0, speed * deltaTime, 0);
                break;
        }
    }  
}
