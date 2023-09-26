using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class Movement : NetworkBehaviour
{
    public float moveVelocity;
    public float turnAngle;
    public float posRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void OnNetworkSpawn()
    {
        transform.position = new Vector3(Random.RandomRange(posRange, -posRange), 0, Random.RandomRange(posRange, -posRange));
        transform.rotation = new Quaternion(0, 90, 0, 0);

    }
    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0f, v);
        dir.Normalize();

        transform.Translate(dir * moveVelocity * Time.deltaTime, Space.World);

        if (dir != Vector3.zero)
        {
            Quaternion rotate = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotate, turnAngle * Time.deltaTime);
        }
    }
}
