﻿using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
    public GameObject player;
    public GameObject kid;
    public GameObject red;
    public GameObject menu;
    public GameObject menuOptions;
    public GameObject menuBase;
    public GameObject door;
    public GameObject house;
    public Camera mainCam;
    public Camera menuCam;
    public Material green;
    public AudioMixer music;
    public Slider musicVolume;

    private GameObject[] lights;

    private void StartScene()
    {
        player = GameObject.FindWithTag("Player");
        kid = GameObject.FindWithTag("Kid");
        door = GameObject.FindWithTag("Door");
        house = GameObject.FindWithTag("Environnement");
        red = GameObject.FindWithTag("RedEyes");
        red.transform.SetPositionAndRotation(new Vector3(18.72f, 15.52f, -29.36f), Quaternion.Euler(0, 0, 0));

        //TODO Create Start Scene
    }

    public void StartingGame()
    {
        //Lights
        lights = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject li in lights)
        {
            li.GetComponent<Light>().enabled = true;
        }

        music.SetFloat("MusicVolume", -80f);
        
        StartScene();

        //Music
        music.SetFloat("MusicVolume", musicVolume.value * 40 - 20);

        //Player
        player.GetComponent<Movement>().enabled = true;
        player.GetComponent<Rotation>().enabled = true;
        player.GetComponent<Escape>().enabled = true;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().freezeRotation = false;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        //Kid
        kid.transform.SetPositionAndRotation(new Vector3(18f, 30f, -28f), Quaternion.Euler(0, 0, 0));
        kid.GetComponent<LightsOff>().enabled = true;
        kid.GetComponent<LightsOff>().timer = 0;
        kid.GetComponent<Spawn>().enabled = true;
        kid.GetComponent<Spawn>().timer = 0;
        kid.GetComponent<CheckSee>().enabled = false;

        //RedEyes
        red.GetComponent<Rigidbody>().freezeRotation = false;
        red.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        red.GetComponent<Pathfinding>().enabled = false;
        red.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        
        //Switches
        GameObject.FindWithTag("S0").GetComponent<Renderer>().material = green;
        GameObject.FindWithTag("S0").GetComponent<Switch>().enabled = false;
        GameObject.FindWithTag("S1").GetComponent<Renderer>().material = green;
        GameObject.FindWithTag("S1").GetComponent<Switch>().enabled = false;
        GameObject.FindWithTag("S2").GetComponent<Renderer>().material = green;
        GameObject.FindWithTag("S2").GetComponent<Switch>().enabled = false;

        //Menu
        menu.SetActive(false);
        menuBase.SetActive(false);
        menuOptions.GetComponent<ToOptions>().inGame = true;

        //Cameras
        menuCam.enabled = false;
        mainCam.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
