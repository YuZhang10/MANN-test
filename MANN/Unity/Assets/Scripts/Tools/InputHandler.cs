using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	private static List<HashSet<KeyCode>> Keys = new List<HashSet<KeyCode>>();
	private static int Capacity = 2;
	private static int Clients = 0;

	private static string[] moves = {"W","W","W","W","W","W","WQ","WQ","WE","WE",
									"Q","Q","E","E","A","D"};
	private static System.Random randomChooseMoves = new System.Random();
	private string lastMove = "W";

	private static int singleMoveMaxLenth = 100;//100frames = 2 seconds
	private int singleMoveLenth = singleMoveMaxLenth;

	void OnEnable() {
		Clients += 1;
	}

	void OnDisable() {
		Clients -= 1;
	}

	public static bool anyKey {
		get{
			for(int i=0; i<Keys.Count; i++) {
				if(Keys[i].Count > 0) {
					return true;
				}
			}
			return false;
		}
	}

	void Update () {
		while(Keys.Count >= Capacity) {
			Keys.RemoveAt(0);
		}
		HashSet<KeyCode> state = new HashSet<KeyCode>();

		// raw input by keyboard
		// foreach(KeyCode k in Enum.GetValues(typeof(KeyCode))) {
		// 	if(Input.GetKey(k)) {
		// 		// Console.WriteLine("pressing key:{0}\t",k);
		// 		state.Add(k);
		// 	}
		// }
		// Keys.Add(state);

		// input by random sampling
		string curMove;
		if (singleMoveLenth>0) {
			// 99% follow lastMove
			curMove = lastMove;
			singleMoveLenth -= 1;
		}
		else{
			curMove = moves[randomChooseMoves.Next(moves.Length)];
			lastMove = curMove;
			singleMoveLenth = singleMoveMaxLenth;	
		}
		Console.WriteLine("pressing key:{0}\t",curMove);

		KeyCode k;
		foreach(char kstr in curMove){
			k = (KeyCode) System.Enum.Parse(typeof(KeyCode), kstr.ToString());
			state.Add(k);
			}
		Keys.Add(state);
	}

	public static bool GetKey(KeyCode k) {
		if(Clients == 0) {
			return Input.GetKey(k);
		} else {
			for(int i=0; i<Keys.Count; i++) {
				if(Keys[i].Contains(k)) {
					return true;
				}
			}
			return false;
		}
	}
	
}
