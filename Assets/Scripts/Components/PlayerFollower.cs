using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Update()
    {
        transform.position = _player.position + new Vector3(0, 14, 0);
    }
}
