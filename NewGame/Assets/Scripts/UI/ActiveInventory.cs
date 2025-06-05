using System.Collections;
using Game.Systems;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActiveInventory : Singleton<ActiveInventory>
{
    protected override bool PersistBetweenScenes => false;

    private int activeSlotIndexNum;

    private PlayerControls playerControls;
    private InputAction hotkeyAction;

    protected override void Awake()
    {
        base.Awake();
        playerControls = new PlayerControls();
        hotkeyAction = playerControls.Inventory.Keyboard;
    }

    private void OnEnable() => playerControls.Enable();
    private void OnDisable() => playerControls.Disable();

    private void Start()
    {
        activeSlotIndexNum = RunData.activeSlot;
        ToggleActiveHighlight(activeSlotIndexNum);

        hotkeyAction.performed += OnHotkey;    
    }

    private void OnHotkey(InputAction.CallbackContext ctx) =>
        ToggleActiveSlot((int)ctx.ReadValue<float>());

    private void OnDestroy()
    {
        hotkeyAction.performed -= OnHotkey;      
    }

    public void EquipStartingWeapon() => ToggleActiveHighlight(0);

    private void ToggleActiveSlot(int numValue) => ToggleActiveHighlight(numValue - 1);

    private void ToggleActiveHighlight(int indexNum)
    {
        activeSlotIndexNum = indexNum;
        RunData.activeSlot = activeSlotIndexNum;

        foreach (Transform slot in transform)         // гасим все индикаторы
            slot.GetChild(0).gameObject.SetActive(false);

        transform.GetChild(indexNum).GetChild(0).gameObject.SetActive(true);

        ChangeActiveWeapon();                         // спавним / меняем оружие
    }

    public void ChangeActiveWeapon()
    {
        if (ActiveWeapon.Instance.CurrentActiveWeapon != null)
            Destroy(ActiveWeapon.Instance.CurrentActiveWeapon.gameObject);

        var inventorySlot = transform.GetChild(activeSlotIndexNum)
                                     .GetComponentInChildren<InventorySlot>();
        var weaponInfo = inventorySlot.GetWeaponInfo();

        if (weaponInfo == null)
        {
            ActiveWeapon.Instance.WeaponNull();
            return;
        }

        var newWeapon = Instantiate(weaponInfo.weaponPrefab, ActiveWeapon.Instance.transform);
        PlayerController.Instance.ApplyAppearance(weaponInfo.playerAnimator);
        ActiveWeapon.Instance.NewWeapon(newWeapon.GetComponent<MonoBehaviour>());
    }

    // вызов из UI-портрета
    public void SelectByPortrait(int slotIndex) => ToggleActiveHighlight(slotIndex);
}
