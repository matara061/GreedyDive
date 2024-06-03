using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public List<Achievement> achievementList;

    public int fishCaught = 0;

    public bool AchievementUnloced(string achievementName)
    {
        bool result = false;

        if (achievementList == null)
            return false;

        Achievement[] achievementArray = achievementList.ToArray();
        Achievement a = Array.Find(achievementArray, ach => achievementName == ach.title);

        if (a == null)
            return result;

        result = a.unlocked;

        return result;
    }

    private void Start()
    {
        InitializeAchievements();
    }

    private void InitializeAchievements()
    {
        if (achievementList != null)
            return;

        Debug.Log("New Achievement");

        achievementList = new List<Achievement>
        {
            new ("Catch a Fish", "Catch a fish like the title says", (object o) => fishCaught >= 1)
        };

    }

    private void Update()
    {
        CheckAchievementProgress();
    }

    private void CheckAchievementProgress()
    {
        if (achievementList == null)
            return;

        foreach (var achievement in achievementList)
        {
            achievement.CheckProgress();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Peixe"))
            fishCaught++;
    }
}

public class Achievement
{
    public Achievement(string title, string description, Predicate<object> requirement)
    {
        this.title = title;
        this.description = description;
        this.requirement = requirement;
    }

    public string title;
    public string description;
    public Predicate<object> requirement;

    public bool unlocked;

    public void CheckProgress()
    {
        if (unlocked)
            return;

        if (RequirementsMet())
        {
            Debug.Log($"{title}: {description}");
            unlocked = true;    
        }
    }

    public bool RequirementsMet()
    {
        return requirement.Invoke(null);
    }
}
