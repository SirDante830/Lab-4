using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab5 : MonoBehaviour
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
        //Determine the constitution modifier 
        ConMod = (ConScore - 10) / 2;

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

        HitDie = HitDie / 2;
        Debug.Log("Averaged health per level is " + HitDie);




        HP = (HitDie * Level) + (ConMod * Level);
        Debug.Log("My character " + CharName + " is a level " + Level + " " + ClassName + " with a CON score of " + ConScore + " and is " + DwarfGrammar + "a Hill Dwarf and " + ToughGrammar + " the Tough feat.  "
            + CharName + " has " + HP + " max health.");
        Debug.Log("(" + HitDie + " * " + Level + ") + (" +  ConMod + " * " + Level + ") is " + HP);
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
