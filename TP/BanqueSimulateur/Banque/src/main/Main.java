package main;

import entities.Client;
import entities.Compte;
import entities.CompteASeuil;
import entities.CompteASeuilRemunere;
import entities.CompteRemunere;
import exceptions.RetirerDepasserSeuil;

public class Main {

	public static void main(String[] args) {
		System.out.println("Bonjour");
		CompteASeuil comS_lc = new CompteASeuil(110.00);
		CompteASeuilRemunere comSR_lc = new CompteASeuilRemunere();
		System.out.println("Avant la transaction");
		comS_lc.afficher();
		comSR_lc.afficher();
		try {
			((CompteASeuil)comS_lc).retirer(105.50);
		} catch (Exception e) {
			e.printStackTrace();
		}
		try {
			comSR_lc.retirer(975.50);
		} catch (Exception e) {
			e.printStackTrace();
		}
		System.out.println("Apr�s la transaction");
		comS_lc.afficher();
		comSR_lc.afficher();
	}
}