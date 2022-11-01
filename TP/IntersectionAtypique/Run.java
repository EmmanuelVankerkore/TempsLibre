package main;

public class Run {

	public static void main(String[] args) {
		
		long valeur1 = 4;
		long valeur2 = 5;
		
		if (verificationIntervallesValeurs(valeur1, valeur2)){
			affichageResultat(fonctionJointure(valeur1, valeur2));
		}
		else {
			System.out.println("L'une des deux valeurs est n'est pas compris dans l'intervalle [1; 20 000 000]");
		}
	}
	
	public static long fonctionJointure(long a, long b) {
		
		boolean jointuretrouvee = false;
		
		while (!jointuretrouvee) {
			if (a == b) {
				jointuretrouvee = true;
				return a;
			}
			else {
				if (a<b) {
					a = calculNouvelleValeur(a, retourneComposition(a));
				}
				else {
					b = calculNouvelleValeur(b, retourneComposition(b));
				}
				
				if (a > 99999900 || b > 99999900) {
					jointuretrouvee = true;
					a = -1;
				}
				System.out.println("a = " + a + " et b = " + b);
			}
		}
		return a;
	}
	
	public static int[] retourneComposition(long nombre) {
		
		int chiffre;
		int composition[] = {-1, -1, -1, -1, -1, -1, -1, -1};
		int increment_composition = 0;
		long[] base10 = {10000000, 1000000, 100000, 10000, 1000, 100, 10, 1};
		
		for (long i : base10) {
			if (nombre>= i && nombre<i*10) {
				chiffre = (int)Math.floor(nombre/i);
				nombre -= chiffre*i;	
				composition[increment_composition] = chiffre;
				increment_composition += 1;
			}
		}
		return composition;
	}
	
	public static long calculNouvelleValeur(long valeur, int[] composition) {
		for (int i : composition) {
			if (i != -1) {
				valeur += i;
			}
		}
		return valeur;
	}
	
	public static void affichageResultat(long resultat) {
		if (resultat != -1) {
			System.out.println("Le nombre jointure est de " + resultat);
		}
		else {
			System.out.println("Le nombre jointure est trop grand.");
		}
	}
	
	public static boolean verificationIntervallesValeurs(long a, long b) {
		if (a > 0 && a<= 20000000 && b> 0 && b <= 20000000) {
			return true;
		}
		else {
			return false;
		}
	}
	
	public static void afficherCouple(int a, int b) {
		System.out.println(a + b);
	}
}
