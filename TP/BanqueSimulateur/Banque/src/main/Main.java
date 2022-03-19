package main;

import entities.Client;
import entities.Compte;
import entities.CompteASeuil;
import entities.CompteASeuilRemunere;
import entities.CompteRemunere;

public class Main {

	public static void main(String[] args) {
		System.out.println("Bonjour");
		CompteASeuilRemunere ev = new CompteASeuilRemunere();
		ev.afficher();
	}
}