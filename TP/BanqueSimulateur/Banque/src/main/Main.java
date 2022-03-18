package main;

import entities.CompteRemunere;

public class Main {

	public static void main(String[] args) {
		System.out.println("Bonjour");
		CompteRemunere com_ev = new CompteRemunere(1000.00);
		com_ev.afficher();
		System.out.println("Avant ajout des intérêts");
		com_ev.verserInteret();
		System.out.println("Après ajout des intérêts");
		com_ev.afficher();
	}
}