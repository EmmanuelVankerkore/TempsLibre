package main;

import entities.CompteASeuil;

public class Main {

	public static void main(String[] args) {
		System.out.println("Bonjour");
		CompteASeuil com_ev = new CompteASeuil(110.00);
		com_ev.afficher();
	}
}