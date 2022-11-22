using AncientAliens.GridSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AncientAliens.TileObjects
{
    public class BarbarianAI : MonoBehaviour
    {
        PathMovement path;
        public bool isCombining;
        TileObjectSoundPlayer soundPlayer;


        private void Awake()
        {
            soundPlayer = GetComponent<TileObjectSoundPlayer>();
            path = GetComponent<PathMovement>();
            path.onPathReached += StartDamagingWonder;
        }

        private void Start()
        {
            var targetTile = GameManager.Instance.AdjacentWonderTiles[Random.Range(0, 12)].index;
            path = GetComponent<PathMovement>();
            path.GetPathTo(EasyGrid.GetTileAt(targetTile), GameRules.barbarianTypeFilter);

            path.onMoved += soundPlayer.PlayOnMoveSFX;
        }

        private void OnDestroy()
        {
            path.onPathReached -= StartDamagingWonder;
            path.onMoved -= soundPlayer.PlayOnMoveSFX;
        }

        private void StartDamagingWonder()
        {
            StartCoroutine(DamageWonder());
        }

        IEnumerator DamageWonder()
        {
            while(path.pathReached)
            {

                if (GameManager.Instance.GamePaused)
                {
                    yield return new WaitForEndOfFrame();
                    continue;
                }

                yield return new WaitForSeconds(GameRules.barbarianActionTick);

                if (GameManager.Instance.GamePaused || isCombining)
                {
                    continue;
                }

                GameManager.Instance.WonderBuildProgress -= GameRules.damageToWonder;

            }
        }
    }
}
