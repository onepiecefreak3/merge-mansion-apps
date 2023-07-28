using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Metaplay.Client.Messages;
using Metaplay.Core;
using Metaplay.Core.Localization;
using Metaplay.Core.Message;
using Metaplay.Core.Network;
using Metaplay.Core.Player;
using Metaplay.Unity.Localization;

namespace Metaplay.Unity
{
    public sealed class MetaplayLocalizationManager
    {
        //private LogChannel _log; // 0x10
        private LocalizationDownloadCache _dlCache; // 0x18
        private Dictionary<LanguageId, ContentHash> _builtinLanguages; // 0x20
        private CancellationTokenSource _stopCts; // 0x28
        private Dictionary<LanguageId, ContentHash> _serverLocalizationVersions; // 0x30
        private IMetaplayLocalizationDelegate _delegate; // 0x38
        private bool _hasSession; // 0x40

        internal MetaplayLocalizationManager()
        {
            _stopCts = new CancellationTokenSource();
            _stopCts.Cancel();

            if (MetaplayCore.Options.FeatureFlags.EnableLocalizations)
                _dlCache = new LocalizationDownloadCache();
        }

        internal void Start(IMetaplayLocalizationDelegate managerDelegate)
        {
            _delegate = managerDelegate;

            MetaplaySDK.MessageDispatcher.AddListener<UpdateLocalizationVersions>(OnUpdateLocalizationVersions);
            MetaplaySDK.MessageDispatcher.AddListener<SessionProtocol.SessionStartSuccess>(OnSessionStarted);
            MetaplaySDK.MessageDispatcher.AddListener<DisconnectedFromServer>(OnDisconnectedFromServer);

            if (!MetaplayCore.Options.FeatureFlags.EnableLocalizations)
                MetaplaySDK.ActiveLanguage = new LocalizationLanguage(LanguageId.FromString("none"), ContentHash.None, new Dictionary<TranslationId, string>());
            else
            {
                _builtinLanguages = BuiltinLanguageRepository.GetBuiltinLanguages();
                MetaplaySDK.ActiveLanguage = BuiltinLanguageRepository.GetAppStartLocalization();

                _dlCache.Start();
            }

            _stopCts = new CancellationTokenSource();
        }

        internal void Stop()
        {
            _delegate = null;
            _hasSession = false;

            MetaplaySDK.MessageDispatcher.RemoveListener<UpdateLocalizationVersions>(OnUpdateLocalizationVersions);
            MetaplaySDK.MessageDispatcher.RemoveListener<SessionProtocol.SessionStartSuccess>(OnSessionStarted);
            MetaplaySDK.MessageDispatcher.RemoveListener<DisconnectedFromServer>(OnDisconnectedFromServer);

            _dlCache.Stop();
            _stopCts.Cancel();
        }

        // ReSharper disable once InconsistentNaming
        internal void AfterSDKInit()
        {
            if (MetaplayCore.Options.FeatureFlags.EnableLocalizations && _delegate != null)
                _delegate.OnInitialLanguageSet();
        }

        private void OnUpdateLocalizationVersions(UpdateLocalizationVersions update)
        {
            _serverLocalizationVersions = update.LocalizationVersions;
            HandleServerLocalizationsChanged();
        }

        private void OnSessionStarted(SessionProtocol.SessionStartSuccess sessionStart)
        {
            _hasSession = true;

            _serverLocalizationVersions = sessionStart.LocalizationVersions;
            HandleServerLocalizationsChanged();
        }

        private void OnDisconnectedFromServer(DisconnectedFromServer _)
        {
            _hasSession = false;
        }

        private void HandleServerLocalizationsChanged()
        {
            if (!MetaplayCore.Options.FeatureFlags.EnableLocalizations)
                return;

            if (_serverLocalizationVersions.TryGetValue(MetaplaySDK.ActiveLanguage.LanguageId, out var locHash))
                return;

            if (MetaplaySDK.ActiveLanguage.Version == locHash)
                return;

            var fetch = FetchLanguageAsync(MetaplaySDK.ActiveLanguage.LanguageId, MetaplaySDK.ActiveLanguage.Version,
                MetaplaySDK.CdnAddress, MetaplaySDK.Connection.Config.ConfigFetchAttemptsMaxCount,
                MetaplaySDK.Connection.Config.ConfigFetchTimeout, _stopCts.Token);

            if (_delegate?.AutoActivateLanguageUpdates == null)
                return;

            fetch = WithCancelAtSdkStop(fetch);
            EnqueueSwitchToLanguageOnComplete(fetch, null);
        }

        private Task<LocalizationLanguage> WithCancelAtSdkStop(Task<LocalizationLanguage> fetchTask)
        {
            return fetchTask.ContinueWith(async task =>
            {
                var result = await task;
                _stopCts?.Token.ThrowIfCancellationRequested();

                return result;
            }).Result;
        }

        private void EnqueueSwitchToLanguageOnComplete(Task<LocalizationLanguage> fetchTask, Action onCompleted)
        {
            fetchTask.ContinueWith(task =>
            {
                if (task.Status < TaskStatus.RanToCompletion)
                    return default;

                if (task.Status == TaskStatus.RanToCompletion)
                {
                    // Log debug "Language fetch completed. Switching to language {Language}, version {Version}."
                    UpdateActiveLanguage(task.Result);

                    var langInfo = MetaplaySDK.SessionContext?.PlayerContext?.Journal?.StagedModel?.GameConfig?.Languages?.GetValueOrDefault(task.Result.LanguageId);
                    var change = new PlayerChangeLanguage(langInfo, task.Result.Version);
                    //MetaplaySDK.SessionContext?.PlayerContext?.ExecuteAction(change);

                    onCompleted?.Invoke();
                }
                else if (task.Status == TaskStatus.Canceled)
                {
                    // Log debug "Language fetch completed but switch request was already cancelled. Ignored."
                }
                else if (task.Status == TaskStatus.Faulted)
                {
                    // Log warning "Language fetch failed: {Error}"
                    onCompleted?.Invoke();
                }

                return task.Result;
            });
        }

        private void UpdateActiveLanguage(LocalizationLanguage localization)
        {
            MetaplaySDK.ActiveLanguage = localization;
            _delegate.OnActiveLanguageChanged();
        }

        public Task<LocalizationLanguage> FetchLanguageAsync(LanguageId language, ContentHash version,
            MetaplayCdnAddress cdnAddress, int numFetchAttempts, MetaDuration fetchTimeout, CancellationToken ct)
        {
            if (!MetaplayCore.Options.FeatureFlags.EnableLocalizations)
                throw new NotSupportedException("MetaplayLocalizationManager.FetchLanguageAsync requires EnableLocalizations feature to be enabled");

            if (_builtinLanguages.TryGetValue(language, out var langHash) && langHash == version)
                return BuiltinLanguageRepository.GetLocalizationAsync(language);

            return _dlCache.GetLocalizationAsync(language, version, cdnAddress, numFetchAttempts, fetchTimeout, ct);
        }

        internal void ActivateSessionStartLanguage(LocalizationLanguage localization)
        {
            MetaplaySDK.ActiveLanguage = localization;
            _delegate.OnActiveLanguageChanged();
        }

        public void OnSessionStart(SessionProtocol.SessionStartSuccess startSuccess, IPlayerModelBase model)
        {
            if (!MetaplayCore.Options.FeatureFlags.EnableLocalizations)
                return;

            switch (model.LanguageSelectionSource)
            {
                case LanguageSelectionSource.UserSelected:
                    BuiltinLanguageRepository.StoreAppStartLanguage(model.Language);
                    break;
            }
        }

        public void SetCurrentLanguage(LanguageId language, Action onCompleted)
        {
            if (!MetaplayCore.Options.FeatureFlags.EnableLocalizations)
                throw new NotSupportedException("MetaplayLocalizationManager.SetCurrentLanguage requires EnableLocalizations feature to be enabled");

            // Log debug "Language change to {language} requested."

            var builtinVersion = _builtinLanguages.GetValueOrDefault(language);
            if (builtinVersion != ContentHash.None)
                BuiltinLanguageRepository.StoreAppStartLanguage(language);

            Task<LocalizationLanguage> runFetch;

            var serverVersion = _serverLocalizationVersions?.GetValueOrDefault(language) ?? ContentHash.None;
            if (_hasSession && serverVersion != builtinVersion)
            {
                // Log debug "Built-in language {language} is not up-to-date, try fetch from CDN (or cache)."

                var fetchTask = _dlCache.GetLocalizationAsync(language, serverVersion, MetaplaySDK.CdnAddress, MetaplaySDK.Connection.Config.ConfigFetchAttemptsMaxCount, MetaplaySDK.Connection.Config.ConfigFetchTimeout, CancellationToken.None);
                runFetch = Task.Run(async () => await fetchTask);
            }
            else
            {
                // Log debug "Completing request by using built-in localization for {language}."

                runFetch = BuiltinLanguageRepository.GetLocalizationAsync(language);
            }

            EnqueueSwitchToLanguageOnComplete(WithCancelAtSdkStop(runFetch), onCompleted);
        }
    }
}
