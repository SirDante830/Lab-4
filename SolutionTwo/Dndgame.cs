using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dndgame : MonoBehaviour
{
   public string NameInput;
   public int LevelInput;
   public string ClassInput;
   public int ConscoreInput;
   public bool HillDwarf;
   public bool Toughness;
   public bool Israndomized;
    void Start()
    {
      charactertypes player1 = new charactertypes(NameInput,LevelInput,ClassInput,ConscoreInput,HillDwarf,Toughness,Israndomized);
    }
}
