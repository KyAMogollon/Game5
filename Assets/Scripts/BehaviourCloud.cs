using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourCloud : MonoBehaviour
{
    [SerializeField] GameObject Cloud;
    [SerializeField] GameObject Cloud1;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cloud.transform.position = new Vector3(Cloud.transform.position.x + speed * Time.deltaTime, Cloud.transform.position.y, Cloud.transform.position.z);
        Cloud1.transform.position = new Vector3(Cloud1.transform.position.x + speed * Time.deltaTime, Cloud1.transform.position.y, Cloud1.transform.position.z);
        if (Cloud.transform.position.x >= 14)
        {
            Cloud.transform.position = new Vector3(-14, Cloud.transform.position.y, Cloud.transform.position.z);
        }
        if (Cloud1.transform.position.x >= 14 )
        {
            Cloud1.transform.position = new Vector3(-14, Cloud1.transform.position.y, Cloud1.transform.position.z);
        }
    }
}
