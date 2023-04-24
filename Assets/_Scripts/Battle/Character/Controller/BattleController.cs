using System.Collections.Generic;
using Battle.Character.Base;
using Cinemachine;
using Cysharp.Threading.Tasks;
using Extensions;
using Framework.framework.resources.api;
using UnityEngine;

namespace Battle.Character.Controller
{
    public class BattleController : MonoBehaviour
    {
        public static BattleController Ins;
        public Camera Camera;
        public List<CharacterBase> Characters;
        public List<CharacterBase> Enemies;
        public List<CharacterBase> Players;

        private IResourceSystemService resourceSystemService =>
            GameContext.Instance.GetService<IResourceSystemService>();

        private void Awake()
        {
            Ins = this;
            CreateBattleCamrea();
        }

        private void CreateBattleCamrea()
        {
            var obj = new GameObject("Camera");
            obj.SetParent(transform);
            Camera = obj.AddComponent<Camera>();
            obj.AddComponent<CinemachineBrain>();
        }

        public void RebornPlayers()
        {
            foreach (var characterBase in Players)
            {
                characterBase.Reborn();
            }
        }

        public async void CreatePlayer(string path)
        {
            var prefab = await resourceSystemService.LoadAsync<GameObject>(path);
            var obj = Instantiate(prefab);
            obj.transform.position = Vector3.zero;

            var characterBase = obj.GetComponent<CharacterBase>();
            const string modelPath = "Assets/ResPackage/Common/Prefab/Player/Barbarian.prefab";
            characterBase.Init(modelPath);

            Players.Add(characterBase);
            Characters.Add(characterBase);
        }

        public async void CreateEnemy(string path)
        {
            var prefab = await resourceSystemService.LoadAsync<GameObject>(path);
            var obj = Instantiate(prefab);
            obj.transform.position = Vector3.zero;

            var character = obj.GetComponent<CharacterBase>();
            const string modelPath = "Assets/ResPackage/Common/Prefab/Enemy/Demon.prefab";
            character.Init(modelPath);
            Enemies.Add(character);
            Characters.Add(character);
        }

        public CharacterBase FindNearTarget(CharacterBase characterBase)
        {
            var dis = characterBase.CharacterData.FindPathDistance;
            var minDis = float.MaxValue;
            var minIndex = 0;
            for (var index = 0; index < Players.Count; index++)
            {
                var player = Players[index];
                var distance = Vector3.Distance(characterBase.transform.position, player.transform.position);
                if (!(distance < dis)) continue;
                if (!(distance < minDis)) continue;
                minIndex = index;
                minDis = distance;
            }

            return Players[minIndex];
        }

        public async UniTask<GameObject> LoadModel(string path)
        {
            var prefab = await resourceSystemService.LoadAsync<GameObject>(path);
            return Instantiate(prefab);
        }
    }
}