using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BulletManager : MonoBehaviour
{
    [SerializeField] BulletController bulletPrefab;
    public BulletController[] bulletControllers { get; set; }

    public void OnStart(Transform shootPoint)
    {
        bulletControllers = new BulletController[Variables.bulletCount];
        for (int i = 0; i < bulletControllers.Length; i++)
        {
            bulletControllers[i] = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity, shootPoint);
            bulletControllers[i].OnStart();
        }
    }

    void Update()
    {
        CheckFailed();
    }

    void CheckFailed()
    {
        if (Variables.screenState != ScreenState.Game) { return; }
        bool isShootedAll = bulletControllers.All(b => b.bulletState == BulletState.Hided);
        if (!isShootedAll) { return; }
        Variables.screenState = ScreenState.Failed;
    }

    public void ShootNextBullet(Vector3 vec)
    {
        var bullet = bulletControllers
            .Where(b => b.bulletState == BulletState.Waiting)
            .FirstOrDefault();
        if (bullet == null) { return; }
        bullet.Shoot(vec);
        SoundManager.i.PlayOneShot(0);
    }

    public int GetUsedCount()
    {
        return bulletControllers.Where(b => b.bulletState != BulletState.Waiting).Count();
    }

    public int GetLeftCount()
    {
        return bulletControllers.Where(b => b.bulletState == BulletState.Waiting).Count();
    }
}
