using UnityEngine;
using System.Collections;
using System;
using UdpKit;

public class Menu : Bolt.GlobalEventListener
{
    public void StartSeerver()
    {
        // サーバーを立てる
        BoltLauncher.StartServer();
    }

    public void StartClient()
    {
        // 他のサーバーに入る
        BoltLauncher.StartClient();
    }


    public override void BoltStartDone()
    {
        if (BoltNetwork.IsServer)
        {
            string matchName = Guid.NewGuid().ToString();

            BoltNetwork.SetServerInfo(matchName, null);
            BoltNetwork.LoadScene("Scene");
        }
    }

    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {
        Debug.LogFormat("Session list updated: {0} total sessions", sessionList.Count);

        foreach (var session in sessionList)
        {
            UdpSession photonSession = session.Value as UdpSession;

            if (photonSession.Source == UdpSessionSource.Photon)
            {
                BoltNetwork.Connect(photonSession);
            }
        }
    }
}
