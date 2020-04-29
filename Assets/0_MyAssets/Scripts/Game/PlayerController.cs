using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Transform armAxis;
    [SerializeField] Transform shootPoint;
    [SerializeField] BulletManager bulletManager;
    LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        bulletManager.OnStart(shootPoint);
    }


    void Update()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 armVec = mousePos - transform.position;
        armAxis.eulerAngles = new Vector3(0, 0, Vector2ToDegree(armVec));

        Vector3 shootVec = mousePos - shootPoint.position;
        lineRenderer.SetPosition(0, shootPoint.position);
        lineRenderer.SetPosition(1, shootPoint.position + shootVec.normalized * 20f);


        if (Input.GetMouseButtonDown(0))
        {
            bulletManager.ShootNextBullet(shootVec);
        }
    }

    public static float Vector2ToDegree(Vector2 vec)
    {
        return Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
    }
}
