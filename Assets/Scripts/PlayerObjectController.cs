using Steamworks;
using Unity.Collections;
using Unity.Netcode;

public class PlayerObjectController : NetworkBehaviour
{
    public NetworkVariable<int> ConnectionID;
    public NetworkVariable<int> PlayerIdNumber;
    public NetworkVariable<ulong> PlayerSteamID;
    public NetworkVariable<FixedString512Bytes> PlayerName;

    private CustomNetworkManager manager;

    private CustomNetworkManager Manager
    {
        get
        {
            if (manager != null)
            {
                return manager;
            }
            return CustomNetworkManager.Singleton;
        }
    }

    public override void OnNetworkSpawn()
    {
        SetPlayerNameRpc(SteamFriends.GetPersonaName().ToString());
        gameObject.name = "LocalGamePlayer";
        LobbyController.instance.FindLocalPlayer();
        LobbyController.instance.UpdateLobbyName();
    }

    public void OnStartClient()
    {
        Manager.GamePlayers.Add(this);
        LobbyController.instance.UpdateLobbyName();
        LobbyController.instance.UpdatePlayerList();
    }

    private void OnStopClient(ulong stuff)
    {
        Manager.GamePlayers.Remove(this);
        LobbyController.instance.UpdatePlayerList();
    }

    [Rpc(SendTo.Server)]
    public void SetPlayerNameRpc(string name)
    {
        this.PlayerNameUpdate(this.PlayerName.Value.ToString(), name);
    }

    private void Start()
    {
        NetworkManager.Singleton.OnClientDisconnectCallback += OnStopClient;
        PlayerName.OnValueChanged += PlayerNameUpdate;
    }

    private void PlayerNameUpdate(FixedString512Bytes previous, FixedString512Bytes current)
    {
        if (IsServer)
        {
            this.PlayerName.Value = current;
        }
        if (IsClient)
        {
            LobbyController.instance.UpdatePlayerList();
        }
    }
}
