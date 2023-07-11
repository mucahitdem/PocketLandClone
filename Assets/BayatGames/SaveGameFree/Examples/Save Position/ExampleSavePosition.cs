using System;
using BayatGames.SaveGameFree.Serializers;
using BayatGames.SaveGameFree.Types;
using UnityEngine;

namespace BayatGames.SaveGameFree.Examples
{
    [Serializable]
    public class StorageSG
    {
        public DateTime myDateTime;

        public StorageSG()
        {
            myDateTime = DateTime.UtcNow;
        }
    }

    public class ExampleSavePosition : MonoBehaviour
    {
        private string _encodePassword;
        public string identifier = "exampleSavePosition.dat";
        public bool loadOnStart = true;

        public Transform target;

        private void Start()
        {
            _encodePassword = "12345678910abcdef12345678910abcdef";
            SaveGame.EncodePassword = _encodePassword;
            SaveGame.Encode = true;
            SaveGame.Serializer = new SaveGameBinarySerializer();
            var ssg = new StorageSG();
            SaveGame.Save("pizza2", ssg);
            var ssgLoaded = SaveGame.Load<StorageSG>("pizza2");
            Debug.Log(ssgLoaded.myDateTime.ToLocalTime().ToString());
            if (loadOnStart) Load();
        }

        private void Update()
        {
            var newPosition = target.position;
            newPosition.x += Input.GetAxis("Horizontal");
            newPosition.y += Input.GetAxis("Vertical");
            target.position = newPosition;
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        public void Save()
        {
            SaveGame.Save<Vector3Save>(identifier, target.position, SerializerDropdown.Singleton.ActiveSerializer);
        }

        public void Load()
        {
            target.position = SaveGame.Load<Vector3Save>(
                identifier,
                Vector3.zero,
                SerializerDropdown.Singleton.ActiveSerializer);
        }
    }
}