package main;

import entities.Client;
import entities.Compte;

public class Main {

	public static void main(String[] args) {
		System.out.println("Bonjour");
		Compte com_ev1 = new Compte(3000.02);
		Compte com_ev2 = new Compte(10.49);
		Client cli_ev = new Client("Vankerkore", "Emmanuel", 28);
		cli_ev.ajouterUnCompte(com_ev1);
		cli_ev.ajouterUnCompte(com_ev2);
		System.out.println("Avant le transfert");
		cli_ev.consulterTousMesComptes();
		cli_ev.transfertCompteAVersComteB(com_ev1, com_ev2);
		System.out.println("Après le transfert");
		cli_ev.consulterTousMesComptes();
	}
}