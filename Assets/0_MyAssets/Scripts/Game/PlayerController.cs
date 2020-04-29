using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Transform armAxis;
    [SerializeField] Transform shootPoint;
    BulletManager bulletManager;
    LineRenderer lineRenderer;
    Vector3 shootVec;
    public void OnStart(BulletManager bulletManager)
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        bulletManager.OnStart(shootPoint);
        this.bulletManager = bulletManager;
    }


    void Update()
    {
        if (Variables.screenState != ScreenState.Game) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            lineRenderer.enabled = true;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3 armVec = mousePos - transform.position;
            armAxis.eulerAngles = new Vector3(0, 0, Vector2ToDegree(armVec));

            shootVec = mousePos - shootPoint.position;
            lineRenderer.SetPosition(0, shootPoint.position);
            lineRenderer.SetPosition(1, shootPoint.position + shootVec.normalized * 20f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            bulletManager.ShootNextBullet(shootVec);
            lineRenderer.enabled = false;
        }
    }

    public static float Vector2ToDegree(Vector2 vec)
    {
        return Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
    }
}
