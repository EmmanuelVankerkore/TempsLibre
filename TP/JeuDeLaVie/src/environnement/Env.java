package environnement;

import cellule.Cel;

public class Env {

	public static int[][] generateEnvironnement(){
		int tableau[][] = new int[30][90];
		for (int i = 0; i < tableau.length; i++) {
			for (int j = 0; j < tableau[0].length; j++) {
				tableau[i][j] = (int)Math.ceil(Math.random()*2-1);
			}
		}
		return tableau;
	}
	
	public static void afficherEnvironnementBinaire(int[][] tableau) {
		for (int i = 0; i < tableau.length; i++) {
			for (int j = 0; j < tableau[0].length; j++) {
				 System.out.print(tableau[i][j]+" ");;
			}
			System.out.println("");
		}
	}
	
	public static void afficherEnvironnement(int[][] tableau) {
		for (int i = 0; i < tableau.length; i++) {
			for (int j = 0; j < tableau[0].length; j++) {
				if (tableau[i][j] == 0) { 
					System.out.print("  ");
				}
				else {
					System.out.print("* ");
				}
			}
			System.out.println("");
		}
	}
	
	public static int[][] renvoyerEnvironnementApres(int[][] environnement) {
		int[][] resultat = new int[environnement.length][environnement[0].length];
		int nombrecellulesvivantes;
		for (int i = 0; i < environnement.length; i++) {
			for (int j = 0; j < environnement[0].length; j++) {
				nombrecellulesvivantes = Cel.nombreCelluleVivantesAutour(environnement, i, j);
				if (nombrecellulesvivantes < 2 || nombrecellulesvivantes > 3) {
					resultat[i][j] = 0;
				}
				else if (nombrecellulesvivantes == 3) {
					resultat[i][j] = 1;
				}
				else {
					resultat[i][j] = environnement[i][j];
				}
			}
		}
		return resultat;
	}
	
	public static void testTableauMulti() {
		int tableau[][][] = new int[10][8][40];
		System.out.println(tableau.length); // taille de la première dimension
		System.out.println(tableau[0].length); // taille de la seconde dimension
		System.out.println(tableau[0][0].length); // taille de la troisième dimension
	}
}
