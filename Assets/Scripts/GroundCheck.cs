using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == playerController.gameObject)
        {
            return;
        }

        playerController.SetGrounded(true);
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject == playerController.gameObject)
        {
            return;
        }

        playerController.SetGrounded(true);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == playerController.gameObject)
        {
            return;
        }

        playerController.SetGrounded(false);
    }
}
