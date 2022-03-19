package main;

import entities.Client;
import entities.Compte;
import entities.CompteASeuil;
import entities.CompteRemunere;

public class Main {

	public static void main(String[] args) {
		System.out.println("Bonjour");
		Compte com_lc = new Compte(1800.00);
		CompteASeuil comS_lc = new CompteASeuil(110.00);
		CompteRemunere comR_lc = new CompteRemunere(100.00);
		CompteRemunere comR2_lc = new CompteRemunere(200.00);
		Client lc = new Client("Cohen", "Lola", 22);
		lc.ajouterUnCompte(com_lc);
		lc.ajouterUnCompte(comS_lc);
		lc.ajouterUnCompte(comR_lc);
		lc.ajouterUnCompte(comR2_lc);
		System.out.println("Avant l'application des intérêts dans les comptes rems");
		lc.consulterTousMesComptes();
		lc.verserInteretSurMesCompteRemunere();
		System.out.println("Apres l'application des intérêts dans les comptes rems");
		lc.consulterTousMesComptes();
	}
}