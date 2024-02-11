using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]public class charactertypes
{
    public string Customname;
    public int Characterlevel;
    public string Classtype;
    public int CONscore;
    private int conmod;
    public int DiceValue;
    public int modifier;
    private int Average;
    private int health;
    public int dwarfhealth;
    private string DwarfStatus;
    public int toughHealth;
    private string ToughStatus;

    public bool IsDwarf;
    public bool IsTough;
    public bool Isitrandomized;
    private string RandomOrAverage;
    public int diceoutput;
   
    public charactertypes(string Username, int Clevel,string Classrole,int con,bool isdwarf,bool toughness,bool randomize)
    {
        Customname = Username;
        Characterlevel = Clevel;
        Classtype = Classrole;
        CONscore = con;
        IsDwarf = isdwarf;
        IsTough = toughness;
        Isitrandomized = randomize;
        Characterprint();
    }

    public void Characterprint()
    {
      modifier = (CONscore-11) /2;
      DiceValue = classAssign();
      Average = DiceValue/2;
        Debug.Log($"{Average}");
      if(IsDwarf == true && IsTough == false)
        {
            modifier += 1;
            DwarfStatus = "is";
            ToughStatus = "doesn't have";
        }
      if(IsTough == false && IsDwarf == true)
        {
            modifier += 2;
            DwarfStatus = "is not";
            ToughStatus = "has";
        }
       if(IsTough == true && IsDwarf == true)
        {
            modifier += 3;
            DwarfStatus = "is";
            ToughStatus = "has";
        }
        else if(IsTough==false && IsDwarf ==false)
        {
            DwarfStatus = "is not";
            ToughStatus = "doesn't have";
        }
        if(Isitrandomized == true)// randomize from ranges starting at 1-max dice value
        {
         RandomOrAverage = "randomized"; 
         DiceValue = Random.Range(1,DiceValue);
         diceoutput = DiceValue;
        }
        else if(Isitrandomized ==false)
        {
          diceoutput = Average;
          RandomOrAverage = "averaged";

        }
      

      Debug.Log($"({diceoutput} * {Characterlevel}) + ({modifier} *{Characterlevel})");
      health = (diceoutput * Characterlevel) + (modifier * Characterlevel);
      Debug.LogFormat("My character {0} is a level {1} {2} with a CONscore of {3} and {4} a Hill Dwarf and {5} Tough feat. I want the Hp {6}.",this.Customname, this.Characterlevel, this.Classtype, this.CONscore,this.DwarfStatus,this.ToughStatus,this.RandomOrAverage);
      Debug.LogFormat("The max Hp for {0} is {1}", this.Customname, this.health);
    }
    public int classAssign()
    {
        //Random rand = new Random()
        switch (Classtype)
        {
            case "Wizard":
            case "Sorcerer":
                DiceValue = 6;
                break;
            case "Artificer":
            case "Bard":
            case "Cleric":
            case "Druid":
            case "Monk":
            case "Rogue":
            case "Warlock":
                DiceValue = 8;
                break;
            case "Paladin":
            case "Ranger" :
            case "Fighter" :
                DiceValue = 10;
                break;
            case "Barbarian":
                DiceValue = 12;
                break;
            default:
                Debug.Log("Wrong info");
                break;
        }
        return DiceValue;
    }
}
