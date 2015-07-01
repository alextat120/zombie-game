using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MoveScript : MonoBehaviour
{
	// 1 - Designer variables
	
	/// <summary>
	/// Object speed
	/// </summary>
	public Vector2 speed = new Vector2(10, 10);
	public int damage;
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);
	
	private Vector2 movement;
	
	void Update()
	{
		// 2 - Movement
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		GetComponent<Rigidbody2D>().velocity = movement;
	}
	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.name == "Enemy"||other.gameObject.name=="Enemy(Clone)") {
			other.GetComponent<PlayerStats>().ChangeHealth(-(damage));
			other.GetComponentInChildren<ParticleSystem>().Emit (10);
		}
	}
}