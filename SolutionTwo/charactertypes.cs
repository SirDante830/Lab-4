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
    public int toughHealth;

    public bool IsDwarf;
    public bool IsTough;
  
    
    //Creates a constructor that recognizes the username and character level from the user
    public charactertypes(string Username, int Clevel)
    {
        Customname = Username;
        Characterlevel = Clevel;
        Characterprint();
    }
    public charactertypes(string Username, int Clevel,string Classrole,int con)
    {
        Customname = Username;
        Characterlevel = Clevel;
        Classtype = Classrole;
        CONscore = con;
        Characterprint();
        
    }
    public void Characterprint()
    {
       //Make formulas for modifier, DiceValue, and Average
      modifier = (CONscore-11)/2;

      //Call classAssign function to use the value based on class
      DiceValue = classAssign();
      Average = DiceValue/2;
      

     //Use if/else to add to modifier if player wants dwarf and/or toughness
      if(IsDwarf == true && IsTough == false)
        {
            modifier += 1;
        }
      if(IsTough == true && IsDwarf == false)
        {
            modifier += 2;
        }
      else if(IsTough == true && IsDwarf == true)
        {
            modifier += 3;
        }

      //Sends calculation to debug
      Debug.Log($"({Average} * {Characterlevel}) + ({modifier} *{Characterlevel}");
      health = (Average * Characterlevel) + (modifier * Characterlevel);
     

       
        Debug.LogFormat(" Your modifier is :{0}", modifier);

        Debug.LogFormat(" Your HP average is :{0}", Average);
        Debug.LogFormat(" Your dice is :{0}", DiceValue);
        Debug.LogFormat(" Your health is :{0}", health);
        Debug.LogFormat(" Your tough health is :{0}", toughHealth);
        Debug.LogFormat(" Your dwarf health is :{0}", dwarfhealth);
        Debug.LogFormat("My character {0} is a level {1} {2} with a conscore of {3} and a dice value of {4}",this.Customname, this.Characterlevel, this.Classtype, this.CONscore, this.DiceValue);
    }
    public int classAssign()
    {
        //Create a switch case that assigns the dice value based on the class

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
