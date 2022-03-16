package test;

import entities.Client;
import entities.Compte;

public class Test {

	public void compteAfficher() {
		Compte EV = new Compte(200.00);
		EV.afficher();
	}
	
	public void compteAjouter() {
		Compte EV = new Compte(550.20);
		EV.ajouter(350.00);
	}
	
	public void compteRetirer() {
		Compte EV = new Compte(58.41);
		EV.retirer(50.00);
	}
	
	public void ajouterUnCompteAUnClient() {
		Compte com_ev = new Compte(3000.20);
		Client cli_ev = new Client("Vankerkore", "Emmanuel", 28);
		cli_ev.ajouterUnCompte(com_ev);
	}
	
	public void empecherLAjoutDUnSixiemeCompte() {
		Compte com_ev1 = new Compte(3000.20);
		Compte com_ev2 = new Compte(250.10);
		Compte com_ev3 = new Compte(10.49);
		Compte com_ev4 = new Compte(10.49);
		Compte com_ev5 = new Compte(5.99);
		Compte com_ev6 = new Compte(100000.01);
		Client cli_ev = new Client("Vankerkore", "Emmanuel", 28);
		cli_ev.ajouterUnCompte(com_ev1);
		cli_ev.ajouterUnCompte(com_ev2);
		cli_ev.ajouterUnCompte(com_ev3);
		cli_ev.ajouterUnCompte(com_ev4);
		cli_ev.ajouterUnCompte(com_ev5);
		cli_ev.ajouterUnCompte(com_ev6);
	}
	
	public void afficherLeNombreDeCompteDuClient() {
		Compte com_ev = new Compte(3000.20);
		Client cli_ev = new Client("Vankerkore", "Emmanuel", 28);
		cli_ev.afficherNbComptes();
		cli_ev.ajouterUnCompte(com_ev);
		cli_ev.afficherNbComptes();
	}
	
	public void consulterLensembleDesComptes() {
		Compte com_ev1 = new Compte(3000.20);
		Compte com_ev2 = new Compte(250.10);
		Compte com_ev3 = new Compte(10.49);
		Client cli_ev = new Client("Vankerkore", "Emmanuel", 28);
		cli_ev.ajouterUnCompte(com_ev1);
		cli_ev.ajouterUnCompte(com_ev2);
		cli_ev.ajouterUnCompte(com_ev3);
		cli_ev.consulterTousMesComptes();
	}
	
	public void transfererEtSupprimerUnCompteClient() {
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
