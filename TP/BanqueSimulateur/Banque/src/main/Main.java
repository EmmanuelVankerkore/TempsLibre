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
		System.out.println("Avant la transfert de 500");
		cli_ev.consulterTousMesComptes();
		cli_ev.transfertCompteAVersCompteBPartiel(com_ev1, com_ev2, 500.00);
		System.out.println("Après le transfert de 500");
		cli_ev.consulterTousMesComptes();
	}
}