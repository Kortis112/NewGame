using UnityEngine;
using UnityEngine.InputSystem;

public class StickAttackProxy : MonoBehaviour
{
    [SerializeField] private float deadZone = 0.2f;

    private PlayerControls input;
    private Vector2 aim;
    public static Vector2 AimDir;           // ← глобальный, нормализованный
    public static bool StickActive;
    private void Awake()
    {
        input = new PlayerControls();
        input.Combat.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>();
        input.Combat.Aim.canceled += _ => aim = Vector2.zero;
    }
    private void OnEnable() => input.Enable();
    private void OnDisable() => input.Disable();

    private void Update()
    {
        bool stickHeld = aim.sqrMagnitude > deadZone * deadZone;
        StickActive = stickHeld;
        AimDir = stickHeld ? aim.normalized : Vector2.zero;
        // «Зажимаем» виртуальную кнопку атаки
        ActiveWeapon.Instance.attackHeldByStick = stickHeld;
        // Поворот оружия в сторону стика (по желанию)
        if (stickHeld)
            ActiveWeapon.Instance.transform.right = aim;
    }
}
