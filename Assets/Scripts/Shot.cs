using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private GameObject shot;

    // Start is called before the first frame update
    void Start()
    {
        // 弾に格納する値
        // PlayerManagerというｵﾌﾞｼﾞｪｸﾄを見つける
        //shot = GameObject.Find(ShotManager);
    }

    // Update is called once per frame
    void Update()
    {
        //var shotSpeed = shot.GetSpeed();  // 弾のｽﾋﾟｰﾄﾞ
        
        // 大きさ1のﾍﾞｸﾄﾙ
        //var shotAngle = shot.GetAngle();   // 弾が動く向き

        // 位置に速度を加算する
       // transform.Translate(shotAngle * shotSpeed);
    }
}
