using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDetectNPC : MonoBehaviour
{
    public  List<GameObject> targetNPC = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC") && !targetNPC.Contains(collision.gameObject))
        {
            targetNPC.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC") && targetNPC.Contains(collision.gameObject))
        {
            targetNPC.Remove(collision.gameObject);
        }
    }
}
