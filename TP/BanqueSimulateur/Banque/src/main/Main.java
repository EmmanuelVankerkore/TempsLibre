package main;

import entities.Client;
import entities.Compte;

public class Main {

	public static void main(String[] args) {
		System.out.println("Bonjour");
		Compte com_ev1 = new Compte(3000.02);
		Compte com_ev2 = new Compte(10.49);
		Compte com_ev3 = new Compte(110.91);
		Compte com_ev4 = new Compte(1.60);
		Compte com_ev5 = new Compte(500.00);
		Client cli_ev = new Client("Vankerkore", "Emmanuel", 28);
		cli_ev.ajouterUnCompte(com_ev1);
		cli_ev.ajouterUnCompte(com_ev2);
		cli_ev.ajouterUnCompte(com_ev3);
		cli_ev.ajouterUnCompte(com_ev4);
		cli_ev.ajouterUnCompte(com_ev5);
		cli_ev.afficherInformationCompte(1002);
	}
}