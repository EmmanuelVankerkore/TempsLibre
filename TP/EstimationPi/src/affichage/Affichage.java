package affichage;

import java.text.DecimalFormat;

public class Affichage {

	public static void afficherValeurFourchette(Double valeur, int valeurPrecision) {
		String formatValeur = "#.";
		for (int i = 0; i < valeurPrecision; i++ ) {
			formatValeur = formatValeur + "#";
		}
		DecimalFormat df = new DecimalFormat(formatValeur);
		System.out.println(df.format(valeur));
	}
}
