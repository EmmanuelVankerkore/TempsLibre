package run;

import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.Test;
import org.junit.jupiter.api.DisplayName;

public class T_Manipulation {
	
	@Test
	@DisplayName("Vérification si la valeur est négative et réelle")
	public void test__GetSigneNegatifReel() {
		assertEquals(Manipulation.getSigne(-4.508), "- 4.508");
	}
	
	@Test
	@DisplayName("Vérification si la valeur est négative, réelle et se termine par zéro ")
	public void test__GetSigneNegatifReelZero() {
		assertEquals(Manipulation.getSigne(-4.51100), "- 4.511");
	}
	
	@Test
	@DisplayName("Vérification si la valeur est négative et entière")
	public void test__GetSigneNegatifEntier() {
		assertEquals(Manipulation.getSigne(-4), "- 4");
	}
	
	@Test
	@DisplayName("Vérification si la valeur est négative, entière et se termine par zéro")
	public void test__GetSigneNegatifEntierZero() {
		assertEquals(Manipulation.getSigne(-4.0000), "- 4");
	}

	@Test
	@DisplayName("Vérification si la valeur est positive et entière")
	public void test__GetSignePositifReel() {
		assertEquals(Manipulation.getSigne(12.85), "+ 12.85");
	}
	
	@Test
	@DisplayName("Vérification si la valeur est positive, réel et se termine par zéro")
	public void test__GetSignePositifReelZero() {
		assertEquals(Manipulation.getSigne(10.4400), "+ 10.44");
	}
	
	@Test
	@DisplayName("Vérification si la valeur est positive et entière")
	public void test__GetSignePositifEntier() {
		assertEquals(Manipulation.getSigne(17), "+ 17");
	}
	
	@Test
	@DisplayName("Vérification si la valeur est positive, entière et se termine par zéro")
	public void test__GetSignePositifEntierZero() {
		assertEquals(Manipulation.getSigne(79.000), "+ 79");
	}
	
	@Test
	@DisplayName("Vérification si la valeur est un réel")
	public void test__GererValeurReel() {
		assertEquals(Manipulation.gererValeurEntiere(88.85), "88.85");
	}
	
	@Test
	@DisplayName("Vérification si la valeur est un réel mais suivi d'au moins un 0")
	public void test__GererValeurReelSuiviZero() {
		assertEquals(Manipulation.gererValeurEntiere(125.0500), "125.05");
	}
	
	@Test
	@DisplayName("Vérification si la valeur est un entier")
	public void test__GererValeurEntier() {
		assertEquals(Manipulation.gererValeurEntiere(9), "9");
	}
	
	@Test
	@DisplayName("Vérification si la valeur est un entier mais suivi d'au moins un 0")
	public void test__GererValeurEntierSuiviZero() {
		assertEquals(Manipulation.gererValeurEntiere(34.000), "34");
	}
	
	@Test
	@DisplayName("Vérification si l'on transforme bien un entier en chaîne de caractère")
	public void test__ToString() {
		assertEquals(Manipulation.toString(15.97), "15.97");
	}
	
	@Test
	@DisplayName("Vérification que l'on ne récupère pas les deux derniers caractères")
	public void test__Sub2LastChar() {
		assertEquals(Manipulation.sub2LastChar("Moto"), "Mo");
	}

}
