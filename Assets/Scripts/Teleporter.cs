using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject Player;
    public GameObject TeleportTo;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Player.transform.position = TeleportTo.transform.position;
            Destroy(gameObject);
        }
    }
}