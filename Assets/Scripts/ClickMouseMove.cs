using UnityEngine;

[RequireComponent(typeof(IMovePosition))]
public class ClickMouseMove : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            GetComponent<IMovePosition>().SetMovePoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
