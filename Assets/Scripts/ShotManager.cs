using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{
    // ﾌﾟﾚｲﾔｰのﾏﾈｰｼﾞｬｰが生成した弾の設定を格納する
    GameObject shotSetting;

    struct shot{
        float speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        // 弾に格納する値
        // PlayerManagerというｵﾌﾞｼﾞｪｸﾄを見つける
        shotSetting = GameObject.Find(PlayerMgr);
    }

    // Update is called once per frame
    void Update()
    {
        // 弾の種類
        var shotType = shotSetting.GetShotType();
        // 弾生成
        Instantiate(shotType, shotSetting.GetPos(), Quaternion.identity);
    }

    // 弾のｽﾋﾟｰﾄﾞを渡す
    float GetSpeed()
    {
        return shotSetting.GetSpeed();
    }

    // 向きを渡す
    Vector3 GetAngle()
    {
        return shotSetting.GetAngle();
    }

}
