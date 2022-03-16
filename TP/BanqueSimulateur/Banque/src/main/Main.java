package main;

import entities.Client;
import entities.Compte;

public class Main {

	public static void main(String[] args) {
		System.out.println("Bonjour");
		Compte com_ev1 = new Compte(3000.02);
		Compte com_ev2 = new Compte(10.49);
		Compte com_ev3 = new Compte(2.89);
		Client cli_ev = new Client("Vankerkore", "Emmanuel", 28);
		cli_ev.ajouterUnCompte(com_ev1);
		cli_ev.ajouterUnCompte(com_ev2);
		cli_ev.ajouterUnCompte(com_ev3);
		System.out.println("Avant la suppression");
		cli_ev.consulterTousMesComptes();
		cli_ev.transfertEtSupprimeCompte(com_ev1, com_ev3);
		System.out.println("Après la suppression");
		cli_ev.consulterTousMesComptes();
	}
}