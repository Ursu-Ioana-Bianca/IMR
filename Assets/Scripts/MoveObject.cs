using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectCSpeed;
    Transform NextPos;
    int NextPosIndex;
    public GameObject target;
    public GameObject obj1;
    public GameObject Cube2;
    public GameObject Cube;
    [SerializeField] float number=2;
    [SerializeField] float minDistance=15;
    // Start is called before the first frame update
    void Start()
    {
        NextPos=Positions[0];
    }

    // Update is called once per frame
    void Update()
    {

        // transform.position= Vector3.MoveTowards(transform.position,target.transform.position,
        // 10f*Time.deltaTime);
        MoveGameObject();
        
    }

    void MoveGameObject()
    {
        
        float distance= (obj1.transform.position - target.transform.position).magnitude;
        Debug.Log(distance);
        if(transform.position==NextPos.position)
        {
          NextPosIndex++;
          if(NextPosIndex >= Positions.Length)
          {
              NextPosIndex=0;
          }
          NextPos=Positions[NextPosIndex];
         
        }
        else 
        {
            this.transform.position=Vector3.MoveTowards(transform.position,NextPos.position+new Vector3(10*target.transform.localScale.x, 0, 0), ObjectCSpeed*Time.deltaTime);
            if (distance<minDistance)
            {   var cubeColor = Cube2.GetComponent<Renderer>();
                var cubeColor2 = Cube.GetComponent<Renderer>();
                Cube2.transform.Rotate(Vector3.up*number);
                cubeColor.material.SetColor("_Color", Color.red);
                Cube.transform.Rotate(Vector3.up*number);
                cubeColor2.material.SetColor("_Color", Color.yellow);
            }
        }

        
    }

}
