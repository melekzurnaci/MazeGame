using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Harf;
   private BoxCollider2D col;
    float x1, x2;
    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();


        x1 = transform.position.x - col.bounds.size.x / 2f;
        x2 = transform.position.x + col.bounds.size.x / 2f;


    }
    // Start is called before the first frame update
    void Start()
          
    {
        col = GetComponent<BoxCollider2D>();
        StartCoroutine(SpawnHarf(1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnHarf(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        Vector3 temp = transform.position;
          temp.x = Random.Range(x1, x2);

        Instantiate(Harf[Random.Range(0, Harf.Length)], temp, Quaternion.identity);

        StartCoroutine(SpawnHarf(Random.Range(1f, 2f)));

    }
}
