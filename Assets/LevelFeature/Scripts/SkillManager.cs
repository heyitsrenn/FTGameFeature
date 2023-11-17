using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public bool skillChosen = false;

    public SkillUI[] necromancySkillUIs;
    public SkillUI[] alchemySkillUIs;
    public SkillUI[] movementSkillUIs;
    public SkillUI[] elementalSkillUIs;
    public SkillUI[] superHumanSkillUIs;

    void Start()
    {
        SetStates();
        SetSkillManagers();
    }

    public void UpdateAllUI()
    {
        foreach (SkillUI skillUI in necromancySkillUIs)
        {
            skillUI.UpdateUI();
        }
        foreach (SkillUI skillUI in alchemySkillUIs)
        {
            skillUI.UpdateUI();
        }
        foreach (SkillUI skillUI in movementSkillUIs)
        {
            skillUI.UpdateUI();
        }
        foreach (SkillUI skillUI in elementalSkillUIs)
        {
            skillUI.UpdateUI();
        }
        foreach (SkillUI skillUI in superHumanSkillUIs)
        {
            skillUI.UpdateUI();
        }
    }
    public void LockSkills()
    {
        if(skillChosen == true)
        {
            foreach (SkillUI skillUI in necromancySkillUIs)
            {
                if(skillUI.skill.state == Skill.State.Unlocked)
                {
                    skillUI.skill.SetState(Skill.State.Locked);
                }
            }
            foreach (SkillUI skillUI in alchemySkillUIs)
            {
                if (skillUI.skill.state == Skill.State.Unlocked)
                {
                    skillUI.skill.SetState(Skill.State.Locked);
                }
            }
            foreach (SkillUI skillUI in movementSkillUIs)
            {
                if (skillUI.skill.state == Skill.State.Unlocked)
                {
                    skillUI.skill.SetState(Skill.State.Locked);
                }
            }
            foreach (SkillUI skillUI in elementalSkillUIs)
            {
                if (skillUI.skill.state == Skill.State.Unlocked)
                {
                    skillUI.skill.SetState(Skill.State.Locked);
                }
            }
            foreach (SkillUI skillUI in superHumanSkillUIs)
            {
                if (skillUI.skill.state == Skill.State.Unlocked)
                {
                    skillUI.skill.SetState(Skill.State.Locked);
                }
            }
        }
    }
    public void SetStates()
    {
        CheckState(necromancySkillUIs);
        CheckState(alchemySkillUIs);
        CheckState(movementSkillUIs);
        CheckState(elementalSkillUIs);
        CheckState(superHumanSkillUIs);
    }
    public Skill.State GetCorrectState(SkillUI[] type, int i)
    {
        if (i == 0 && type[i].skill.state != Skill.State.Activated)
        {
            return Skill.State.Unlocked;
        }
        if (i != 0 && type[i].skill.state != Skill.State.Activated && type[i - 1].skill.state == Skill.State.Activated)
        {
            return Skill.State.Unlocked;
        }
        if (type[i].skill.state == Skill.State.Activated)
        {
            return Skill.State.Activated;
        }
        return Skill.State.Locked;
    }

    public void CheckState(SkillUI[] type)
    {
        for (int i = 0; i < type.Length; i++)
        {
            type[i].skill.SetState(GetCorrectState(type, i));
        }
    }
    public void SetSkillManagers()
    {
        foreach (SkillUI skillUI in necromancySkillUIs)
        {
            skillUI.SetSkillManager(this.GetComponent<SkillManager>());
        }
        foreach (SkillUI skillUI in alchemySkillUIs)
        {
            skillUI.SetSkillManager(this.GetComponent<SkillManager>());
        }
        foreach (SkillUI skillUI in movementSkillUIs)
        {
            skillUI.SetSkillManager(this.GetComponent<SkillManager>());
        }
        foreach (SkillUI skillUI in elementalSkillUIs)
        {
            skillUI.SetSkillManager(this.GetComponent<SkillManager>());
        }
        foreach (SkillUI skillUI in superHumanSkillUIs)
        {
            skillUI.SetSkillManager(this.GetComponent<SkillManager>());
        }
    }

    public void ResetSkills()
    {
        foreach (SkillUI skillUI in necromancySkillUIs)
        {
            skillUI.skill.SetState(Skill.State.Locked);
        }
        foreach (SkillUI skillUI in alchemySkillUIs)
        {
            skillUI.skill.SetState(Skill.State.Locked);
        }
        foreach (SkillUI skillUI in movementSkillUIs)
        {
            skillUI.skill.SetState(Skill.State.Locked);
        }
        foreach (SkillUI skillUI in elementalSkillUIs)
        {
            skillUI.skill.SetState(Skill.State.Locked);
        }
        foreach (SkillUI skillUI in superHumanSkillUIs)
        {
            skillUI.skill.SetState(Skill.State.Locked);
        }

        SetStates();
        UpdateAllUI();
    }

    public void CheatSkillPoints()
    {
        skillChosen = false;
        SetStates();
        UpdateAllUI();
    }
}
