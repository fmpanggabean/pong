using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Pong.Gameplay.UI {
    public class UIManager : MonoBehaviour {
        private GameManager gameManager;

        private List<BaseUI> uiCollection;

        private void Awake() {
            gameManager = FindObjectOfType<GameManager>();
            uiCollection = FindObjectsOfType<BaseUI>().ToList();
        }

        private void Start() {
            gameManager.score.onScoreAdded += GetUI<ScoreUI>().SetScore;
        }

        private T GetUI<T>() where T : BaseUI{
            foreach(BaseUI ui in uiCollection) {
                if (ui.GetType() == typeof(T)) {
                    return (T)ui;
                }
            }
            return null;
        }
    }

}