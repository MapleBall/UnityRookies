# UnityRookies
宅宅的Unity大冒險

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public float speed = 0.1f;
    public int hp = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.position += new Vector3(speed* deltaTime, 0, 0);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position -= new Vector3(speed * deltaTime, 0, 0);

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.gameObject.transform.position += new Vector3(0, speed * deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.gameObject.transform.position -= new Vector3(0,speed * deltaTime, 0);
        }
        if (hp < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            hp -= 1;

        }
    }

}
