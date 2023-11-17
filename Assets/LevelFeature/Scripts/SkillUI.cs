using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public Skill skill;
    private SkillManager skillManager;
    public Button skillButton;

    public void SetSkillManager(SkillManager _skillManager)
    {
        skillManager = _skillManager;
    }

    void Start()
    {
        Button btn = skillButton.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        UpdateUI();
    }

    void OnClick()
    {
        skill.SetState(Skill.State.Activated);
        skillManager.skillChosen = true;
        skillManager.LockSkills();
        skillManager.UpdateAllUI();
    }
    public void UpdateUI()
    {
        GetComponent<Image>().color = skill.state == Skill.State.Unlocked ? Color.blue : skill.state == Skill.State.Activated ? Color.green : Color.grey;
        if (skill.state == Skill.State.Unlocked)
        {
            skillButton.interactable = true;
        }
        else
        {
            skillButton.interactable = false;
        }
    }

}
