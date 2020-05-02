using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyGame/Create LevelDataSO", fileName = "LevelDataSO")]
public class LevelDataSO : ScriptableObject
{
    public LevelData[] levelDatas;

    private static LevelDataSO _i;
    public static LevelDataSO i
    {
        get
        {
            string PATH = "ScriptableObjects/" + nameof(LevelDataSO);
            //初アクセス時にロードする
            if (_i == null)
            {
                _i = Resources.Load<LevelDataSO>(PATH);

                //ロード出来なかった場合はエラーログを表示
                if (_i == null)
                {
                    Debug.LogError(PATH + " not found");
                }
            }

            return _i;
        }
    }
}

[System.Serializable]
public class LevelData
{
    public int initialBulletCount;
    public int threeStarMinimumBulletLeftCount;
    public int twoStarMinimumBulletLeftCount;
}