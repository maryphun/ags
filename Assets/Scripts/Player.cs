using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Bolt.EntityBehaviour<ICubeStateCustom>
{
    private Camera camera;
    private CharacterController characterController;
    private Animator animator;
    private bool shot;
    //start()
    public override void Attached()
    {
        //network
        state.SetTransforms(state.CubeTransform, transform);
        

        //if (entity.IsOwner)
        //{
        //}

        //player
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        camera = FindObjectOfType<Camera>();
    }
    
    //update()
    public override void SimulateOwner()
    {
        var speed = 5f;
        var movement = Vector3.zero;
        shot = Input.GetMouseButton(0);
        state.Shot = shot;

        if (Input.GetKey(KeyCode.W)) { movement.z += speed; }
        if (Input.GetKey(KeyCode.S)) { movement.z -= speed; }
        if (Input.GetKey(KeyCode.A)) { movement.x -= speed; }
        if (Input.GetKey(KeyCode.D)) { movement.x += speed; }

        Ray cameraRay = camera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

            transform.LookAt(pointToLook);
        }

        if (movement != Vector3.zero)
        {
            transform.position = transform.position + (movement.normalized * speed * BoltNetwork.FrameDeltaTime);
        }

        animator.SetBool("Run", movement != Vector3.zero);
        animator.SetBool("Shot", shot);
    }
}