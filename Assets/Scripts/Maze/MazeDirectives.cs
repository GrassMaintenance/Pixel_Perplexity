using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze {
    public class MazeObjectives : MonoBehaviour {

        public int keysToFind;
        public Text keysValueText;

        public MazeGoal mazeGoalPrefab;
        public MazeKey mazeKeyPrefab;

        private MazeGoal mazeGoal;
        private int foundKeys;
        private List<Vector3> mazeKeyPositions;
        private MazeGenerator mazeGenerator;

        private void OnEnable() {
            MazeGenerator.OnMazeReady += StartObjectives;
        }

        private void OnDisable() {
            MazeGenerator.OnMazeReady -= StartObjectives;
        }

        private void Start() {
            SetKeyValueText();
        }

        private void StartObjectives() {
            mazeGenerator = MazeGenerator.instance;
            mazeGoal = Instantiate(mazeGoalPrefab, mazeGenerator.mazeGoalPosition, Quaternion.identity);
            mazeGoal.transform.SetParent(transform);

            mazeKeyPositions = mazeGenerator.GetRandomFloorPositions(keysToFind);

            foreach (var position in mazeKeyPositions) {
                var mazeKey = Instantiate(mazeKeyPrefab, position, Quaternion.identity);
                mazeKey.transform.SetParent(transform);
            }
        }

        public void OnGoalReached() {
            Debug.Log("Goal Reached");
            if (foundKeys == keysToFind) {
                Debug.Log("Escape the maze");
            }
        }

        public void OnKeyFound() {
            foundKeys++;
            SetKeyValueText();

            if (foundKeys == keysToFind) {
                GetComponentInChildren<MazeGoal>().OpenGoal();
            }
        }

        private void SetKeyValueText() {
            keysValueText.text = $"{foundKeys} of {keysToFind}";
        }
    }
}
