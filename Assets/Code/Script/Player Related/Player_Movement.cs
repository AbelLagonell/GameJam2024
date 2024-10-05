using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour {
    private bool isFiring = false;
    private Vector2 moveInput;
    private Rigidbody rb;
    private GameObject lazerObject;

    public float moveSpeed = 7f;
    public float bulletSpeed = 14f;
    public float chargeTime = 0f;
    public GameObject bullet;
    public GameObject lazer;


    private void Start() {
        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            throw new System.Exception("Object does not have a rigidbody");
        }
        if (bullet == null || lazer == null) {
            throw new System.Exception("Object does not have a projectile prefab");
        }

    }

    private void FixedUpdate() {
        rb.velocity = Vector3.Lerp(new Vector3(rb.velocity.x, rb.velocity.y, 0), new Vector3(moveInput.x, moveInput.y, 0) * moveSpeed, .25f);
        if (isFiring) { StartCoroutine(fireBullets()); }
        if (lazerObject != null) {
            lazerObject.transform.position = this.transform.position + new Vector3(0, 6.5f);
        }
    }

    public void MoveActivated(InputAction.CallbackContext mv) {
        if (mv.started || mv.performed) {
            moveInput = mv.ReadValue<Vector2>();
        }
        if (mv.canceled) { moveInput = Vector2.zero; }
    }

    public void FireActivated(InputAction.CallbackContext fa) {
        if (fa.started || fa.performed) isFiring = true;
        if (fa.canceled) isFiring = false;
    }

    public void AltFireActivated(InputAction.CallbackContext afa) {
        if (afa.performed && chargeTime >= 100) {
            lazerObject = Instantiate(lazer, transform.position + new Vector3(0, 6.5f), Quaternion.identity);
            chargeTime = 0;
        }
    }

    private IEnumerator fireBullets() {
        Instantiate(bullet, transform.position, Quaternion.identity);
        chargeTime++;
        yield return new WaitForSeconds(1f);
    }
}
