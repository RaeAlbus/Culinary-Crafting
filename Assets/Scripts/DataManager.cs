using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    // Your data variables
    public List<List<(List<string>, string)>> allGoals;
    public string[][] ingredients;

    void Start()
    {
        //slots = GameObject.FindGameObjectsWithTag("Slot");
        allGoals = new List<List<(List<string>, string)>>();
        allGoals.Add(new List<(List<string>, string)>());
        allGoals[0].Add((new List<string>{"Water", "Eggs", "Flour", "Sugar", "Bowl"}, "PancakeBatter"));
        allGoals[0].Add((new List<string>{"PancakeBatter", "FryingPan", "Stove"}, "Pancakes"));
        allGoals.Add(new List<(List<string>, string)>());
        allGoals[1].Add((new List<string>{"Water", "Eggs", "Flour", "Sugar", "Bowl"}, "PancakeBatter"));
        allGoals[1].Add((new List<string>{"PancakeBatter", "FryingPan", "Stove"}, "Pancakes"));


        foreach(List<(List<string>, string)> goalI in allGoals) {
            foreach ((List<string>, string) ing in goalI) {
                ing.Item1.Sort();
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<(List<string>, string)> GetFirstDataList()
    {
        if (allGoals.Count > 0) {
            return allGoals[0];
        }
        return null;
    }

    public void RemoveFirst()
    {
        if (allGoals.Count > 0) {
            allGoals.RemoveAt(0);
        }
    }
}
