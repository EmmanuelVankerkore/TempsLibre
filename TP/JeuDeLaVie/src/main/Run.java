package main;

import environnement.Env;
import cellule.Cel;

public class Run {

	public static void main(String[] args) {
		//Env.testTableauMulti();
		int[][] tab = Env.generateEnvironnement();
		int[][] tab2;
		int compteur = 0;
		
		Env.afficherEnvironnement(tab);
		wait(500);
		illusionClearConsole(10);
		
		while (compteur != 1000 && Cel.nombreTotalCellulesVivantes(tab) != 0) {
			tab2 = Env.renvoyerEnvironnementApres(tab);
			Env.afficherEnvironnement(tab2);
			wait(250);
			illusionClearConsole(10);
			tab = tab2.clone();
			compteur += 1;
		}
	}
	
	public static void illusionClearConsole(int nbespace)  {  
		for (int i = 0; i < nbespace; i++) {
			System.out.println("");
		}
	} 
	
	public static void wait(int n) { 
		try
		{
		    Thread.sleep(n);
		}
		catch(InterruptedException ex)
		{
		    Thread.currentThread().interrupt();
		}
	}
}
