using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MazeDirectives : MonoBehaviour {

    public int keysToFind;

    public Text keysValueText;

    public MazeGoal mazeGoalPrefab;
    public MazeKey mazeKeyPrefab;

    MazeGoal mazeGoal;

    int foundKeys;

    List<Vector3> mazeKeyPositions;

    MazeGenerator mazeGenerator;

      void Awake() {
        MazeGenerator.OnMazeReady += StartDirectives;
    }

    void Start() {
        SetKeyValueText();
         keysValueText.text = foundKeys.ToString() + " of " + keysToFind.ToString();
    }


    void StartDirectives() {
        mazeGenerator = MazeGenerator.instance;

        mazeGoal = Instantiate(mazeGoalPrefab, mazeGenerator.mazeGoalPosition, Quaternion.identity) as MazeGoal;
        mazeGoal.transform.SetParent(transform);

        mazeKeyPositions = mazeGenerator.GetRandomFloorPositions(keysToFind);

        for(int i = 0; i < mazeKeyPositions.Count; i++) {
            MazeKey mazeKey = Instantiate(mazeKeyPrefab, mazeKeyPositions[i], Quaternion.identity) as MazeKey;
            mazeKey.transform.SetParent(transform);
        }
    }

    public void OnGoalReached() {
        Debug.Log("Goal Reached");
        if(foundKeys == keysToFind) {
            Debug.Log("Escape the maze");
        }
    }

    public void OnKeyFound() {
        foundKeys++;

        SetKeyValueText();

        if(foundKeys == keysToFind) {
            GetComponentInChildren<MazeGoal>().OpenGoal();
        }
    }

    void SetKeyValueText() {
        keysValueText.text = foundKeys.ToString() + " of " + keysToFind.ToString();
    }

}
