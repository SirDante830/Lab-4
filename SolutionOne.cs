using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionOne : MonoBehaviour
{
    public string CharName;
    public string ClassName;
    public int ConScore;
    private int ConMod;     //The amount of health the character gains per level
    public int Level;
    private int HitDie;     //The class' specific hit die
    private int HP;         //The total HP
    public bool Tough;
    public bool HillDwarf;
    public bool AveragedHealth;
    private string DwarfGrammar;
    private string ToughGrammar;

    Dictionary<string, int> Characters = new Dictionary<string, int>()
    {
        {"Artificer", 8},
        {"Barbarian", 12},
        {"Bard", 8},
        {"Cleric", 8},
        {"Druid", 8},
        {"Figher", 10},
        {"Monk", 8},
        {"Ranger", 10},
        {"Rogue", 8},
        {"Paladin", 10},
        {"Sorcerer", 6},
        {"Wizard", 6},
        {"Warlock", 8}
    };

    // Start is called before the first frame update
    void Start()
    {

        CheckConMod();
        //Check for level
        if(Level < 1)
        {
            Debug.Log("Your level seems suspicious");
        }
        //Fix the output sentence (for better English) and account for race/feat adjustments.  Group them all under ConMod (to avoid more variables).
        if(Tough == true)
        {
            ToughGrammar = "has";
            ConMod += 2;
        }
        else{
            ToughGrammar = "does not have";
        }
        if(HillDwarf == true)
        {
            DwarfGrammar = "";
            ConMod += 1;
        }
        else
        {
            DwarfGrammar = "not ";
        }

        GetHitDie(ClassName);
        Debug.Log("Hit die is " + HitDie);
        
        //Average/Roll health values.  Both done in this if statement.
        if(AveragedHealth == true)
        {
            HitDie = HitDie / 2;
            Debug.Log("Averaged health per level is " + HitDie);
            HP = (HitDie * Level) + (ConMod * Level);
        }
        else
        {
            int TimesToRoll = Level;
            do
            {
                RollHealth();
                TimesToRoll--;
            }while (TimesToRoll != 0);
            HP = HP + (Level * ConMod);
        }

        Debug.Log("(" + HitDie + " * " + Level + ") + (" + ConMod + " * " + Level + ") is " + HP);
        Debug.Log("My character " + CharName + " is a level " + Level + " " + ClassName + " with a CON score of " + ConScore + " and is " + DwarfGrammar + "a Hill Dwarf and " + ToughGrammar + " the Tough feat.  "
            + CharName + " has " + HP + " max health.");
        
    }

    private void RollHealth()
    {
        int rolledHP = 0;
        rolledHP = Random.Range(1, HitDie + 1);
        HP += rolledHP;
        Debug.Log("HitDie rolled " + rolledHP + ", resulting in a current total of " + HP + " health. (Con mod later)");
    }

    private void CheckConMod()
    {
        //Make sure the ConScore is a valid answer
        if(ConScore < 1)
        {
            Debug.Log("Your Con Score seems suspicious");
        }
        //Determine the constitution modifier
        if (ConScore <= 1)
        {
            ConMod = -5;
        }
        else if (ConScore >= 30)
        {
            ConMod = 10;
        }
        else
        {
            ConMod = (ConScore - 10) / 2;
        }
    }

    private void GetHitDie(string cName)
    {
        if(Characters.ContainsKey(cName))
        {
            HitDie = Characters[cName];
            
        }
        else
        {
            Debug.Log("Your class name is not recognized, please make sure it is spelled correctly.");
        }
    }
}
