using Mirror;
using UnityEngine;

public class Lever : NetworkBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        FlipCmd();
    }

    [Command(requiresAuthority = false)]
    private void FlipCmd()
    {
        transform.rotation = Quaternion.Euler(90, 90, 90);
    }
}
