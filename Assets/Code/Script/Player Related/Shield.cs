using UnityEngine;

public class Shield : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "E" + tag) {
            Stat_Tracker.Instance.RecordBulletBlock(tag);
            Destroy(other.gameObject);
        }
    }
}
