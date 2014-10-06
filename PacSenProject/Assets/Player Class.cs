using UnityEngine;
using System.Collections;

//theory

public class PlayerClass : MonoBehaviour {


	class Combat_Character
	{
		private string _name;
		public string Name
		{
			get{return _name;}
			set{_name = value}
		}

		private int _health;
		public int Health
		{
			get{ return _health;}
			set{
				_health = _health - value;
				if (_health < 0) {_health = 0;}
			}
		}

		private int _power;
		public int Power
		{
			get{return _power;}
			set{_power = value;}
		}

		private int _defense;
		public int Defense
		{
			get{return _defense;}
			set{_defense = value;}
		}

		private int _defense;
		public int Defense
		{
			get{return _defense;}
			set{_defense = value;}
		}
		int magic;
		int speed;

		//operational things
		bool combat_clickable;
		bool combat_timer;
		//ToDo: Some form of list of attacks, damages and possible targets
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
