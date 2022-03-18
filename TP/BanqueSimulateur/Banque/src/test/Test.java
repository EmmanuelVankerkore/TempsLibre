package test;

import entities.Client;
import entities.Compte;
import entities.CompteASeuil;
import entities.CompteRemunere;

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
	
	public void tranfertPartielDUnCompteAUnAutre() {
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
	
	public void afficherLesInformationsDuCompteAPartirDuNumero() {
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
	
	public void creationCompteRemunererAvecAffichageDesInformations() {
		CompteRemunere com_ev = new CompteRemunere();
		com_ev.afficher();
	}
	
	public void ajouterInteretsAUnCompteRemunere() {
		CompteRemunere com_ev = new CompteRemunere(1000.00);
		com_ev.afficher();
		System.out.println("Avant ajout des intérêts");
		com_ev.verserInteret();
		System.out.println("Après ajout des intérêts");
		com_ev.afficher();
	}
	
	public void creationCompteASeuilAvecAffichageDesInformations() {
		CompteASeuil com_ev = new CompteASeuil(110.00);
		com_ev.afficher();
	}
	
	public void retirerDuCompteASeuilSiRespectDuSeuil() {
		CompteASeuil com_ev = new CompteASeuil(110.00);
		System.out.println("Avant le premier retrait");
		com_ev.afficher();
		com_ev.retirerAvecRespectDuSeuil(55.00);
		System.out.println("Après le premier retrait");
		com_ev.afficher();
		System.out.println("======================================================================");
		System.out.println("Avant le second retrait");
		com_ev.afficher();
		com_ev.retirerAvecRespectDuSeuil(25.00);
		System.out.println("Après le second retrait");
		com_ev.afficher();
	}
}
