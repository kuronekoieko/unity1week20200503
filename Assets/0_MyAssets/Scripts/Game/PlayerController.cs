using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Transform armAxis;
    LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, armAxis.position);
    }


    void Update()
    {

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        Debug.Log(worldPos);
        Vector3 armVec = worldPos - transform.position;
        armAxis.eulerAngles = new Vector3(0, 0, Vector2ToDegree(armVec));


        lineRenderer.SetPosition(1, worldPos);
        //line.SetPosition関数の第一引数は配列の要素数(配列は0スタートです！,第二引数は座標です)

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        //lineの太さを決められます。
    }

    public static float Vector2ToDegree(Vector2 vec)
    {
        return Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
    }
}
