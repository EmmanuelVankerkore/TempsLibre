package calcul;

public class Calcul {

	/**
	 * La méthode permet de mettre au carré une valeur.
	 * 
	 * @param valeur
	 * @return valeur²
	 */
	
	public static Double auCarre(Double valeur) {
		return Math.pow(valeur, 2);
	}
	
	public static Double arrondirAuInf(Double valeur, int precision) {
		Double mult10 = Math.pow(10, precision);
		return Math.floor(valeur * mult10) / mult10;
	}

	public static Double arrondirAuSup(Double valeur, int precision) {
		Double mult10 = Math.pow(10, precision);
		return Math.ceil(valeur * mult10) / mult10;
	}
	
	public static Double AbsDuPointDepuisDroiteCentreCercle(Double coef) {
		return Math.sqrt( 1 / (1 + Math.pow(coef, 2)) );
	}
	
	public static Double OrdDuPointDepuisDroiteCentreCercle(Double coef) {
		return coef / ( Math.sqrt( 1 + Math.pow(coef, 2))) ;
	}
	
	public static Double FormuleCercle(Double abs, Double ord) {
		return Math.pow(abs, 2) + Math.pow(ord, 2);
	}
}
