package main;

public class Recursive {

	public static void main(String[] args) {
		
		long valeur1 = 2;
		long valeur2 = 10;
		
		if (verificationIntervallesValeurs(valeur1, valeur2)){
			affichageResultat(fonctionJointure2(valeur1, valeur2));
		}
		else {
			System.out.println("L'une des deux valeurs est n'est pas compris dans l'intervalle [1; 20 000 000]");
		}
		
	}
	
	public static boolean verificationIntervallesValeurs(long a, long b) {
		return (a > 0 && a<= 20000000 && b> 0 && b <= 20000000) ? true : false;
	}
	
	public static void affichageResultat(long resultat) {
		
		String texte = "Le nombre jointure est ";
		texte += resultat!=-1 ? "de " + resultat : "trop grand.";
		System.out.println(texte);
	}
	
	public static long fonctionJointure2(long a, long b) {
		
		boolean jointuretrouvee = false;
		
		while (!jointuretrouvee) {
			if (a == b) {
				jointuretrouvee = true;
				return a;
			}
			else {
				if (a<b) {
					int[] tabcompo = {-1};
					a = calculNouvelleValeur(a, recursiveDansUnTableau(tabcompo ,a ,0 ));
				}
				else {
					int[] tabcompo = {-1};
					b = calculNouvelleValeur(b, recursiveDansUnTableau(tabcompo ,b ,0 ));
				}
				
				if (a > 99999900 || b > 99999900) {
					jointuretrouvee = true;
					a = -1;
				}
			}
		}
		return a;
	}
	
	public static long calculNouvelleValeur(long valeur, int[] composition) {
		for (int i : composition) {
			if (i != -1) {
				valeur += i;
			}
		}
		return valeur;
	}
	
	public static int[] recursiveDansUnTableau(int[] composition, long nombre, int nombrechiffre) {
		
		int[] nouveautableau = new int[composition.length+1];
		
		if (nombrechiffre > 0) {
			nouveautableau = copierContenuTab(composition);
		}
		if (nombre>0) {
			nouveautableau[nombrechiffre] =  (int)nombre-((int)Math.ceil(nombre/10))*10;
			return recursiveDansUnTableau(nouveautableau, (int)Math.ceil(nombre/10) , nombrechiffre+1);
		}	
		else {
			return reverseOrdreValeurTableau(composition);
		}	
	}
	
	public static int[] copierContenuTab(int[] tableau) {
		int[] tableautemp = new int[tableau.length+1];
		for (int i = 0; i < tableau.length; i++) {
			tableautemp[i] = tableau[i];
		}
		return tableautemp;
	}
	
	public static int[] reverseOrdreValeurTableau(int[] tableau) {
		int[] tableautemp = new int[tableau.length];
		for (int i = 0; i < tableau.length; i++) {
			tableautemp[tableau.length-i-1] = tableau[i];
		}
		return tableautemp;
	}
	
	public static void afficherCouple(int a, int b) {
		System.out.println(a + b);
	}
}
