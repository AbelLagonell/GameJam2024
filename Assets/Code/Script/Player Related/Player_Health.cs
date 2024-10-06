using UnityEngine;

public class Player_Health : MonoBehaviour {

    public int player;
    [SerializeField] public int health { get; private set; }

    public void Start() {
        health = 10;
    }

    private void Update() {
        if (health <= 0) {
            Stat_Tracker.Instance.GameStateUpdate("Game Over");
        }
    }

    public void DecrementHealth() {
        health--;
        if (Stat_Tracker.Instance != null) {
            Stat_Tracker.Instance.HealthUpdate(player, health);
        }
    }

}
