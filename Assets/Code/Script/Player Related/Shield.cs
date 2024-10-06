using UnityEngine;

public class Shield : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if ("E" + other.tag == tag) {
            Stat_Tracker.Instance.RecordBulletBlock(tag);
            Destroy(other.gameObject);
        }
    }
}
