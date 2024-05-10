using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("XP"))
        {
            other.gameObject.GetComponent<ItemDrop>().PickUpEvent.Invoke();
        }
    }
}
