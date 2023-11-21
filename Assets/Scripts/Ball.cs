using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Score score;
    public GameObject createPrefab;
    public GameObject effect;
    public AudioSource bubbleEffect;
    public string ballTag;
    public int ID;
    public int point;
    private int count=0;

    // Start is called before the first frame update
    void Start()
    {
        bubbleEffect = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        score = GameObject.Find("Score").GetComponent<Score>();
        ID = GetInstanceID();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ballTag)
        {
            if (count<1)
            {
                if (ID > collision.gameObject.GetComponent<Ball>().ID)
                {
                    GameObject b = Instantiate(createPrefab, transform.position, Quaternion.identity);
                    score.UpdateScore(point);
                    bubbleEffect.Play();
                    Instantiate(effect, transform.position, Quaternion.identity);
                    
                    b.name = "c";
                    Destroy(gameObject);
                    Destroy(collision.gameObject);
                    count++;
                }
                else
                {
                    Destroy(gameObject);
                    Destroy(collision.gameObject);
                }
            }

           
        }
    }


}
