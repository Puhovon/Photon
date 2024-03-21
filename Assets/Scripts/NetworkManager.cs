using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject playerSample;
    public Transform spawnPoints;

    private void Start()
    {
        print("Hello");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        options.IsVisible = false;
        PhotonNetwork.JoinOrCreateRoom("test", options, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(playerSample.name, spawnPoints.position, Quaternion.identity);
    }

    public void SayHello()
    {
        this.photonView.RPC("Hello", RpcTarget.All, (byte)photonView.ViewID);
    }

    [PunRPC]
    public void Hello(byte playerId)
    {
        print($"player {playerId} said Hello");
    }
}