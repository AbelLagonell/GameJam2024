using UnityEngine;

public class Shield : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "E" + tag) {
            Stat_Tracker.Instance.RecordBulletBlock(tag);
            Stat_Tracker.Instance.AddScore(20);
            Destroy(other.gameObject);
        }
    }
}
