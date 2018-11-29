using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateCircuit: EditorWindow{
    public GameObject straight;
    public GameObject left;
    public GameObject right;
    public GameObject booster;
    public GameObject killerField;

	public float boosterFieldProbability = 0.3f;
	public float killerFieldProbability = 0.2f;

	public List<char[]> routes = new List<char[]>();
    private char lastRoad = 's';

	[MenuItem("Window/CircuitMaker")]
	public static void ShowWindow(){
		GetWindow<CreateCircuit>("Create Circuit");
	}

	void OnGUI(){
        EditorGUILayout.BeginHorizontal();
		GUILayout.Label("StraightRoad Prefab", EditorStyles.boldLabel);
        straight = EditorGUILayout.ObjectField(straight, typeof(GameObject), true) as GameObject;
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
		GUILayout.Label("LeftTurn Prefab", EditorStyles.boldLabel);
        left = EditorGUILayout.ObjectField(left, typeof(GameObject), true) as GameObject;
        EditorGUILayout.EndHorizontal();
        
		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("RightTurn Prefab", EditorStyles.boldLabel);
        right = EditorGUILayout.ObjectField(right, typeof(GameObject), true) as GameObject;
        EditorGUILayout.EndHorizontal();
        
		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("Booster Prefab", EditorStyles.boldLabel);
        booster = EditorGUILayout.ObjectField(booster, typeof(GameObject), true) as GameObject;
        EditorGUILayout.EndHorizontal();
        
		EditorGUILayout.BeginHorizontal();
		GUILayout.Label("KillerField Prefab", EditorStyles.boldLabel);
        killerField = EditorGUILayout.ObjectField(killerField, typeof(GameObject), true) as GameObject;
        EditorGUILayout.EndHorizontal();

        // GUILayout.Label("Killer Fields", EditorStyles.boldLabel);
        killerFieldProbability = EditorGUILayout.Slider("KillerField Probability",killerFieldProbability, 0f, 0.5f);
        
		// GUILayout.Label("Booster Fields", EditorStyles.boldLabel);
        boosterFieldProbability = EditorGUILayout.Slider("BoosterField Probability",boosterFieldProbability, 0f, 0.5f);
		
		if(GUILayout.Button("Generate Track")){
			destroyCircuit();
			generateCircuit();
		}
	}
	
	private void destroyCircuit(){
        GameObject obj = GameObject.Find("Random Circuit");
        if (obj != null){
            DestroyImmediate(obj);
        }
	}
    // [MenuItem("Extra/Create random circuit")]
	public void generateCircuit(){
		this.prefillRoutes();
		GameObject obj = new GameObject();
        obj.name = "Random Circuit";
        obj.transform.localScale = new Vector3(8f, 1f, 8f);
        List<GameObject> circuit = new List<GameObject>();
		for (int part = 0; part < 4; part++){
			int chosenPart = Random.Range(0, routes.Count);
			char[] circuitPart = routes[chosenPart];
			GameObject road;
			for (int i = 0; i < circuitPart.Length; i++){
				switch (circuitPart[i]){
					case 's':
						road = Instantiate(straight, obj.transform);
						break;
					case 'l':
						road = Instantiate(left, obj.transform);
						break;
					case 'r':
						road = Instantiate(right, obj.transform);
						break;
					default:
						road = Instantiate(straight, obj.transform);
						break;
				}
				if(circuit.Count > 0){
					Transform previousRoad = circuit[circuit.Count - 1].transform;
					switch (lastRoad){
						case 's':
							road.transform.localPosition = previousRoad.localPosition + previousRoad.forward * 2;
							road.transform.rotation = previousRoad.transform.rotation;
							break;
						case 'l':
							road.transform.localPosition = previousRoad.localPosition + previousRoad.forward - previousRoad.right;
							road.transform.localRotation = previousRoad.transform.localRotation;
							road.transform.Rotate(0, -90, 0, Space.Self);
							break;
						case 'r':
							road.transform.localPosition = previousRoad.localPosition + previousRoad.forward + previousRoad.right;
							road.transform.localRotation = previousRoad.transform.localRotation;
							road.transform.Rotate(0, 90, 0, Space.Self);
							break;
					}
				}
				lastRoad = circuitPart[i];
				road.GetComponent<Checkpoint>().checkpointNumber = circuit.Count;
				circuit.Add(road);
				addObstaclesAndBoosters(road);
			}
		}
        Debug.Log(GameObject.FindGameObjectsWithTag("Booster").Length);
	}

	private void prefillRoutes(){
		if(routes.Count > 0) return;
		routes.Add("sssrsss".ToCharArray());
		routes.Add("slsrsssrsrllrrsls".ToCharArray());
		routes.Add("ssslssrrssllssrrssssrsssllr".ToCharArray());
		routes.Add("slsrlrsrlrlrsrlrlrl".ToCharArray());
		routes.Add("srsllssrsrrlsss".ToCharArray());
		routes.Add("srsllrlrrsrls".ToCharArray());
		routes.Add("srslsrs".ToCharArray());
		routes.Add("srssllsssssrrssssss".ToCharArray());
		routes.Add("slrsslsrsrsrlssrsls".ToCharArray());
		routes.Add("sssslslssrrssssrrllrsrsssslslsr".ToCharArray());
	}

	private void addObstaclesAndBoosters(GameObject road){
		// if(this.lastRoad == 'l' || this.lastRoad == 'r') return;
		bool addKiller = Random.Range(0f, 1f) < killerFieldProbability;
		bool addBooster = Random.Range(0f, 1f) < boosterFieldProbability;
		int boosterPosition = -1;
		int killerPosition = -1;
		GameObject gameObject;
		if(addBooster){
			gameObject = Instantiate(booster, road.transform);
			gameObject.transform.rotation = road.transform.localRotation;
            gameObject.transform.Rotate(0, 90, 0, Space.Self);
			boosterPosition = Random.Range(0,6);
			switch (boosterPosition){
				case 0:
					gameObject.transform.localPosition = new Vector3(0.25f,0f,0.4f);
					gameObject.transform.localScale = new Vector3(0.05f,1f,0.25f);
					break;
				case 1:
					gameObject.transform.localPosition = new Vector3(-0.25f,0f,0.4f);
					gameObject.transform.localScale = new Vector3(0.05f,1f,0.25f);
					break;
				case 2:
					gameObject.transform.localPosition = new Vector3(0.25f,0f,1f);
					gameObject.transform.localScale = new Vector3(0.05f,1f,0.25f);
					break;
				case 3:
					gameObject.transform.localPosition = new Vector3(-0.25f,0f,1f);
					gameObject.transform.localScale = new Vector3(0.05f,1f,0.25f);
					break;
				case 4:
					gameObject.transform.localPosition = new Vector3(0f,0f,0.4f);
					gameObject.transform.localScale = new Vector3(0.05f,1f,0.6f);
					break;
				case 5:
					gameObject.transform.localPosition = new Vector3(0f,0f,1f);
					gameObject.transform.localScale = new Vector3(0.05f,1f,0.6f);
					break;
				default:
					break;
			}
		}
		if(addKiller){
            gameObject = Instantiate(killerField, road.transform);
            gameObject.transform.rotation = road.transform.localRotation;
            gameObject.transform.Rotate(0, 90, 0, Space.Self);
            gameObject.transform.localScale = new Vector3(0.01f, 1f, 0.02f);
			killerPosition = Random.Range(0, 4);
            switch (killerPosition)
            {
                case 0:
                    gameObject.transform.localPosition = new Vector3(0.25f, 0f, 0.4f);
                    break;
                case 1:
                    gameObject.transform.localPosition = new Vector3(-0.25f, 0f, 0.4f);
                    break;
                case 2:
                    gameObject.transform.localPosition = new Vector3(0.25f, 0f, 1f);
                    break;
                case 3:
                    gameObject.transform.localPosition = new Vector3(-0.25f, 0f, 1f);
                    break;
                default:
                    break;
            }
		}


	}
}
