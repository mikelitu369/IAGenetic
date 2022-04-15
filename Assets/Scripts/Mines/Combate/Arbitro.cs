using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arbitro : MonoBehaviour
{
    [SerializeField] Text vidaPlayerTxt, vidaIATxt, energyPlayerTxt, energyIATxt, ultimaAccion;

    Individuo IAPlayer;

    int vidaPlayer, vidaIA, energyPlayer, energyIA;

    bool playerTurn;

    Reglas.ataques ultimaJugada = Reglas.ataques.descanso;

    private void Start()
    {
        IAPlayer = new Individuo(PoblacionCombate.ADN_MVP);
        vidaPlayer = vidaIA = 200;
        energyPlayer = energyIA = 10;
        JugadaIA();
    }

    public void UpdateTexts()
    {
        vidaPlayerTxt.text = vidaPlayer.ToString() + " HP";
        vidaIATxt.text = vidaIA.ToString() + " HP";
        energyPlayerTxt.text = energyPlayer.ToString() + " Energy";
        energyIATxt.text = energyIA.ToString() + " Energy";
        ultimaAccion.text = ultimaJugada.ToString();

        if (!playerTurn) JugadaIA();
    }

    public void JugadaIA()
    {
        Reglas.ataques ataque = IAPlayer.SeleccionarAtaque(energyIA);
        if(ataque != Reglas.ataques.descanso)
        {
            energyIA -= Reglas.Coste(ataque);
            vidaPlayer -= Reglas.Atacar(ataque);
        }
        else
        {
            energyIA = 10;
        }
        ultimaJugada = ataque;
        playerTurn = true;
        UpdateTexts();
    }

    public void AtaquePlayer(Reglas.ataques ataque)
    {
        if (!playerTurn) return;
        if (energyPlayer < Reglas.Coste(ataque)) return;
        energyPlayer -= Reglas.Coste(ataque);
        vidaIA -= Reglas.Atacar(ataque);
        playerTurn = false;
        UpdateTexts();
    }

    public void AtaqueFuerte()
    {
        Reglas.ataques ataque = Reglas.ataques.pesado;
        AtaquePlayer(ataque);
    }

    public void AtaqueRandom()
    {
        Reglas.ataques ataque = Reglas.ataques.random;
        AtaquePlayer(ataque);
    }

    public void AtaqueRapido()
    {
        Reglas.ataques ataque = Reglas.ataques.ligero;
        AtaquePlayer(ataque);
    }

    public void AtaquePesimo()
    {
        Reglas.ataques ataque = Reglas.ataques.pesimo;
        AtaquePlayer(ataque);
    }

    public void Descanso()
    {
        energyPlayer = 10;
        playerTurn = false;
        UpdateTexts();
    }
}
