using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseClass {

	private string classname;
	private string description;

	private int strength;
	private int dexterity;
	private int intelligence;
	private int endurance;
	private int agility;
	private int wisdom;

	public string ClassName {
		get{return classname;}
		set{classname = value;}
	}

	public string ClassDescription {
		get{return description;}
		set{description = value;}
	}

	public int Strength {
		get{return strength;}
		set{strength = value;}
	}

	public int Dexterity {
		get{return dexterity;}
		set{dexterity = value;}
	}

	public int Intelligence {
		get{return intelligence;}
		set{intelligence = value;}
	}

	public int Endurance {
		get{return endurance;}
		set{endurance = value;}
	}

	public int Agility {
		get{return agility;}
		set{agility = value;}
	}

	public int Wisdom {
		get{return wisdom;}
		set{wisdom = value;}
	}

}
