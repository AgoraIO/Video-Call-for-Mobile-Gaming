using UnityEngine;
using UnityEngine.EventSystems;

public class UIElementDragger : EventTrigger {

    public override void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        base.OnDrag(eventData);
    }
}