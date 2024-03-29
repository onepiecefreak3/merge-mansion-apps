﻿using System;
using System.Collections.Generic;
using System.Linq;
using GameLogic.Player;
using Metaplay.Core;
using Metaplay.Core.Client;
using Metaplay.Core.Message;
using Metaplay.Core.Player;
using Metaplay.Unity;
using Metaplay.Unity.DefaultIntegration;
using MetaplayIntegration;
using MetaplayIntegration.Deployment;using Microsoft.CSharp.RuntimeBinder;
using UnityEngine;

public class MetaplayClient : ISessionContextProvider
{
    private static IMetaplayClientConnectionDelegate _connectionDelegate; // 0x28

    //public static PlayerClientContext PlayerContext { get; set; }
    public static PlayerModel PlayerModel { get; }

    private SessionProtocol.SessionStartSuccess _initialState; // 0x10
    private List<Action> _pendingSessionFuncs; // 0x18

    IPlayerClientContext ISessionContextProvider.PlayerContext { get; } //=> PlayerContext;
    public MetaplayClientStore ClientStore { get; }

    public MetaplayClient()
    {
        _pendingSessionFuncs = new List<Action>();

        MetaplaySDK.Start(new MetaplaySDKConfig
        {
            BuildVersion = new BuildVersion(Application.Version, "local", "b0e28a097c26fd4d461fe6764533244176df313a"),
            AutoCreateMetaplaySDKBehavior = false,
            ServerEndpoint = GetServerEndpoint(),
            ConnectionConfig = null,
            OfflineOptions = new MetaplayOfflineOptions { PersistState = DeploymentConfig.Instance.PersistOfflineState },
            ConnectionDelegate = _connectionDelegate = new GameConnectionDelegate { SessionContext = this },
            LocalizationDelegate = new DefaultMetaplayLocalizationDelegate(),
            SessionContext = this

            // ...
        });

        // ...

        Update();
    }

    public void Update()
    {
        // Z111
        MetaplaySDK.Update();

        // ...
    }

    private static ServerEndpoint GetServerEndpoint()
    {
        var selected = DeploymentConfig.Selected;
        if (selected.IsOfflineMode)
            return new ServerEndpoint();

        return new ServerEndpoint(selected.ServerHost, selected.ServerPort, selected.EnableTls, selected.CdnBaseUrl, selected.BackupGateways?.Select(x => x.ToGateway(selected.EnableTls)).ToList() ?? new List<ServerGateway>());
    }
}