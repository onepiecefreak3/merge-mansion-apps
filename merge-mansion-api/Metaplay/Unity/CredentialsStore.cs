using System.IO;
using Metaplay.Core;
using Metaplay.Core.Serialization;
using UnityEngine;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Unity
{
    public static class CredentialsStore // TypeDefIndex: 12939
    {
        // Fields
        private const string KeyDeviceId = "did";
        private const string KeyAuthToken = "at";
        private const string KeyPlayerId = "pid";
        // Methods
        private static string GetCredentialStorePath()
        {
            return Path.Combine(MetaplaySDK.PersistentDataPath, "MetaplayCredentials.dat");
        }

        //// RVA: 0x1D17CE0 Offset: 0x1D17CE0 VA: 0x1D17CE0
        //private static string GetCredentialStorePathInEditor() { }
        public static DeviceCredentials TryGetCredentials(out bool hasPendingFileIOError)
        {
            hasPendingFileIOError = false;
            var credPath = GetCredentialStorePath();
            var blob = AtomicBlobStore.TryReadBlob(credPath);
            var devCreds = blob != null ? TryDeserializeCredentialsBlob(blob) : null;
            if (devCreds != null)
            {
                StoreLegacyCredentials(devCreds);
                return devCreds;
            }

            var hasDid = PlayerPrefs.Instance.HasKey(KeyDeviceId);
            var hasAt = PlayerPrefs.Instance.HasKey(KeyAuthToken);
            var hasPid = PlayerPrefs.Instance.HasKey(KeyPlayerId);
            if (!hasDid || !hasAt || !hasPid)
                return null;
            var newCreds = new DeviceCredentials
            {
                DeviceId = PlayerPrefs.Instance.GetString(KeyDeviceId),
                AuthToken = PlayerPrefs.Instance.GetString(KeyAuthToken),
                PlayerId = EntityId.ParseFromString(PlayerPrefs.Instance.GetString(KeyPlayerId))
            };
            hasPendingFileIOError = !TryStoreFileCredentials(newCreds);
            return newCreds;
        }

        public static bool StoreCredentials(DeviceCredentials credentials)
        {
            StoreLegacyCredentials(credentials);
            return TryStoreFileCredentials(credentials);
        }

        private static void StoreLegacyCredentials(DeviceCredentials credentials)
        {
            PlayerPrefs.Instance.SetString(KeyDeviceId, credentials.DeviceId);
            PlayerPrefs.Instance.SetString(KeyAuthToken, credentials.AuthToken);
            PlayerPrefs.Instance.SetString(KeyPlayerId, credentials.PlayerId.ToString());
            PlayerPrefs.Instance.Save();
        }

        private static bool TryStoreFileCredentials(DeviceCredentials credentials)
        {
            var path = GetCredentialStorePath();
            var credBlob = SerializeCredentialsBlob(credentials);
            return AtomicBlobStore.TryWriteBlob(path, credBlob);
        }

        //// RVA: 0x1D18208 Offset: 0x1D18208 VA: 0x1D18208
        //public static void ClearCredentials(bool clearKeychain) { }
        //// RVA: 0x1D182A0 Offset: 0x1D182A0 VA: 0x1D182A0
        //public static void ClearCredentialsInEditor(bool clearKeychain) { }
        private static byte[] SerializeCredentialsBlob(DeviceCredentials credentials)
        {
            var data = new CredentialsData
            {
                DeviceId = credentials.DeviceId,
                AuthToken = credentials.AuthToken,
                PlayerId = credentials.PlayerId
            };
            return MetaSerialization.SerializeTagged(data, MetaSerializationFlags.IncludeAll, null, null);
        }

        private static DeviceCredentials TryDeserializeCredentialsBlob(byte[] blob)
        {
            var data = MetaSerialization.DeserializeTagged<CredentialsData>(blob, MetaSerializationFlags.IncludeAll, null, null, null);
            if (!string.IsNullOrEmpty(data.DeviceId) && !string.IsNullOrEmpty(data.AuthToken) && data.PlayerId.IsValid)
                return new DeviceCredentials
                {
                    DeviceId = data.DeviceId,
                    AuthToken = data.AuthToken,
                    PlayerId = data.PlayerId
                };
            return null;
        }

        public class GmsBlockStoreStore
        {
            private static string GmsBlockStoreLabel;
            public GmsBlockStoreStore()
            {
            }

            [MetaSerializable]
            public class DeviceAuthBlock
            {
                [MetaMember(1, (MetaMemberFlags)0)]
                public int Version;
                [MetaMember(2, (MetaMemberFlags)0)]
                public string AndroidId;
                [MetaMember(3, (MetaMemberFlags)0)]
                public byte[] Credentials;
                public DeviceAuthBlock()
                {
                }
            }
        }
    //// RVA: 0x1D17EF4 Offset: 0x1D17EF4 VA: 0x1D17EF4
    //private static DeviceCredentials PeekKeychainCredentials() { }
    //// RVA: 0x1D18154 Offset: 0x1D18154 VA: 0x1D18154
    //private static void StoreKeychainCredentials(DeviceCredentials deviceCredentials) { }
    //// RVA: 0x1D1829C Offset: 0x1D1829C VA: 0x1D1829C
    //private static void ClearKeychainCredentials() { }
    }
}