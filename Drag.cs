using UnityEngine;
using UnityEngine.EventSystems;


public class Drag : MonoBehaviour, IDragHandler
{
    public void OnDrag (PointerEventData data)
    {
        transform.position = data.position;
    }
}
