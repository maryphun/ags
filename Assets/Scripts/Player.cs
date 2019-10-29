using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Bolt.EntityBehaviour<ICubeStateCustom>
{
    //start()
    public override void Attached()
    {
        state.SetTransforms(state.CubeTransform, transform);

        if (entity.IsOwner)
        {
            state.Color = new Color(Random.value, Random.value, Random.value);
        }
        state.AddCallback("Color", ColorChanged);
    }

    void OnGUI()
    {
        if (entity.IsOwner)
        {
            GUI.color = state.Color;
            GUILayout.Label("@@@");
            GUI.color = Color.white;
        }
    }

    //update()
    public override void SimulateOwner()
    {
        var speed = 4f;
        var movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) { movement.z += 1; }
        if (Input.GetKey(KeyCode.S)) { movement.z -= 1; }
        if (Input.GetKey(KeyCode.A)) { movement.x -= 1; }
        if (Input.GetKey(KeyCode.D)) { movement.x += 1; }

        if (movement != Vector3.zero)
        {
            transform.position = transform.position + (movement.normalized * speed * BoltNetwork.FrameDeltaTime);
        }

        // 弾を撃つ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletPrefab = (GameObject)Resources.Load("Sphere");
            BoltNetwork.Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }

    void ColorChanged()
    {
        GetComponent<Renderer>().material.color = state.Color;
    }
}