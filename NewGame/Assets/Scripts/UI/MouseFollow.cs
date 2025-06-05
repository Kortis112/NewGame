using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollow : MonoBehaviour
{
    private void Update() {
        if (ActiveWeapon.Instance.attackHeldByStick)  // פכאד טח StickAttackProxy
            return;
        FaceMouse();

    }


    private void FaceMouse() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current != null
                    ? Mouse.current.position.ReadValue()
                    : Vector2.zero);

        Vector2 direction = transform.position - mousePosition;

        transform.right = -direction;
    }
}
