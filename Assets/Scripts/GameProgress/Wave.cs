using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine;

public class Wave

{

    private int wave, brainiacs, scuttlers, electors;
    private int currentBrainiacs, currentScuttlers, currentElectors;

    public Wave() {

        this.wave = 0;
        this.brainiacs = 0;
        this.scuttlers = 5;
        this.electors = 0;

        this.currentElectors = electors;
        this.currentScuttlers = scuttlers;
        this.currentBrainiacs = brainiacs;

    }

    public void waveUp() {
        wave++;
        scuttlers += (int) (scuttlers * 0.75);
        if (wave == 2) {
            brainiacs += 5;
        } else {
            brainiacs += (int) (brainiacs * 0.75);
        }

        if (wave % 5 == 0) {
            electors = electors*electors;
        }


        currentBrainiacs = brainiacs;
        currentScuttlers = scuttlers;
        if (wave == 5) {
            currentScuttlers = 0;
            currentBrainiacs = 50;
            electors = 1;
        }
        
        currentElectors = electors;
    }

    public void spawnedCurrentScuttlers(int s)
    {
    this.currentScuttlers -= s;
    }

    public string getWave() {
    return wave.ToString();
    }

    public void spawnedCurrentBrainiacs(int b)
    {
    this.currentBrainiacs -= b;
    }

    public void spawnedCurrentElectors(int e) {
        this.currentElectors -= e;
    }



    public int[] getCurrentEnemies() 
    {
        return new int[3]{currentScuttlers,currentBrainiacs,currentElectors};
    }

}
