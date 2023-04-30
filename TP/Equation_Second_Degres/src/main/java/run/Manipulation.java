package run;

public class Manipulation {
	
	public static String getSigne(double valeur) {
		if (valeur < 0) {
			return "- " + String.valueOf(gererValeurEntiere(-valeur));
		} else {
			return "+ " + String.valueOf(gererValeurEntiere(valeur));
		}
	}
	
	public static String getSigne2(double valeur) {
		if (valeur < 0) {
			return "-" + String.valueOf(gererValeurEntiere(-valeur));
		} else {
			return String.valueOf(gererValeurEntiere(valeur));
		}
	}

	public static String gererValeurEntiere(double d) {
		if (d == (int)d  ) {
			return sub2LastChar(String.valueOf(d));
		} else
			return String.valueOf(d) ;
	}
	
	public static String toString(double d) {
		return String.valueOf(d);
	}
	
	public static String sub2LastChar(String s) {
		return s.substring(0, s.length()-2);
	}
}
