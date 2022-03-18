package main;

import entities.CompteASeuil;

public class Main {

	public static void main(String[] args) {
		System.out.println("Bonjour");
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