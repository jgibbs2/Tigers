using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerClass : MonoBehaviour {

	class Combat_Character
	{
		#region Global Character Variables
		private string _name;
		public string Name
		{
			get{return _name;}
			set{_name = value;}
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

		private int _magic;
		public int Magic
		{
			get{return _magic;}
			set{_magic = value;}
		}

		private int _speed;
		public int Speed
		{
			get{return _speed;}
			set{_speed = value;}
		}
		#endregion
		//make official the stuff below this.
		//operational things
		public bool Ready;
		public float time_passed;
		public float startTime = 0.0f;
		//bool combat_timer;
		//ToDo: Some form of list of attacks, damages and possible targets

		//make constructor that can get and set our private variables.
	}

	List<Combat_Character> Characters = new List<Combat_Character> ();
	//int speed = 5;
	bool ready = false;
	//float startTime = 0.0f;
	public Transform red;
	public Transform green;
	public Transform blue;

	// Use this for initialization
	void Start () {
		Instantiate(red, new Vector3(-5,3,0), Quaternion.identity);// these initialize each character.
		Instantiate (green, new Vector3 (-5, 0, 0), Quaternion.identity);
		Instantiate (blue, new Vector3 (-5, -3, 0), Quaternion.identity);
		//GameObject red = GameObject.Instantiate

		Combat_Character Red = new Combat_Character ();
		Red.Name = "Red";
		Red.Speed = 500;
		Red.Ready = false;
		Characters.Add (Red);
		Combat_Character Green = new Combat_Character ();
		Green.Name = "Green";
		Green.Speed = 700;
		Green.Ready = false;
		Characters.Add (Green);
		Combat_Character Blue = new Combat_Character ();
		Blue.Name = "Blue";
		Blue.Speed = 300;
		Blue.Ready = false;
		Characters.Add (Blue);

	}

	void countDown()
	{
		string message = "";
		float t = Time.time;
		foreach (Combat_Character i in Characters)
		{
			if(i.Ready==false)
			{
				i.time_passed+=(t-i.startTime);
				if(Mathf.Floor(i.time_passed)>=i.Speed)
				{
					message = "Ready";
					i.Ready = true;

				}
				else
				{
					message = Mathf.Floor(i.time_passed).ToString();
				}
				GameObject.Find (i.Name + " Text").GetComponent<TextMesh>().text= message;
			}

		}
		/*int thing;
		thing = Mathf.FloorToInt(Time.time - startTime);
		//GameObject.Find("New Text").GetComponent<TextMesh>().text = (Time.time - startTime).ToString();
		if(thing < (6))//-speed))
		{
			GameObject.Find("New Text").GetComponent<TextMesh>().text = thing.ToString();
			ready = false;
		}
		else	
		{
			GameObject.Find("New Text").GetComponent<TextMesh>().text = "Ready";
			ready = true;
		}*/
	}

	// Update is called once per frame
	void Update () {
		countDown ();
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		

		//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//R//aycastHit hit;
		//Physics2D.Raycast (ray, out hit, 100);
		RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

		Debug.Log (hit.collider.name);
		foreach (Combat_Character i in Characters)
		{
			if(hit.collider.gameObject.name == i.Name+" Character(Clone)" && Input.GetMouseButtonDown(0)&& i.Ready == true)
			{
				i.time_passed = 0.0f;
				i.startTime = Time.time;
				i.Ready = false;
			}
		}
		/*if(ready == false)
		{
			countDown ();
		}
		else if (ready == true)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Physics.Raycast (ray, out hit, 100);
			if (hit.collider.gameObject.name == "Cube"&&Input.GetMouseButtonDown(0))
			{
				ready = false;
				startTime = Time.time;
			}
		}*/
	}
}
