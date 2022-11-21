using System.Collections;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Mover : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity =  Vector3.forward * speed * Time.deltaTime;
    }
}
