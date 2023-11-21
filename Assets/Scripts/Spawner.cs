using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    private bool isSpawned = false;

    
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && isSpawned)
        {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject spawned = GameObject.Find("a");

            spawned.transform.position = new Vector3(Mathf.Lerp(spawned.transform.position.x,clickPos.x,10f), transform.position.y, transform.position.z);
            spawned.GetComponent<Rigidbody2D>().gravityScale = 1;
            Invoke("ChangeObjectName",.3f);
            
            Spawn();
        }
        

    }
    void ChangeObjectName()
    {
        GameObject spawned = GameObject.Find("a");

        
        spawned.name = "b";
    }
    public void Spawn()
    {
        
        StartCoroutine(WaitAndSpawn());
        
        
    }
    IEnumerator WaitAndSpawn()
    {
        isSpawned = false;
        yield return new WaitForSeconds(.7f);
        int a = Random.Range(0, prefabs.Length);
        GameObject spawned = Instantiate(prefabs[a], transform.position, Quaternion.identity);
        spawned.GetComponent<Rigidbody2D>().gravityScale = 0;
        spawned.name = "a";
        isSpawned = true;
    }
    

}
