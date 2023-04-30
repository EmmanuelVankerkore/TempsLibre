package run;

import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.Test;
import org.junit.jupiter.api.DisplayName;

public class T_Manipulation {
	
	@Test
	@DisplayName("V�rification si la valeur est n�gative et r�elle")
	public void test__GetSigneNegatifReel() {
		assertEquals(Manipulation.getSigne(-4.508), "- 4.508");
	}
	
	@Test
	@DisplayName("V�rification si la valeur est n�gative, r�elle et se termine par z�ro ")
	public void test__GetSigneNegatifReelZero() {
		assertEquals(Manipulation.getSigne(-4.51100), "- 4.511");
	}
	
	@Test
	@DisplayName("V�rification si la valeur est n�gative et enti�re")
	public void test__GetSigneNegatifEntier() {
		assertEquals(Manipulation.getSigne(-4), "- 4");
	}
	
	@Test
	@DisplayName("V�rification si la valeur est n�gative, enti�re et se termine par z�ro")
	public void test__GetSigneNegatifEntierZero() {
		assertEquals(Manipulation.getSigne(-4.0000), "- 4");
	}

	@Test
	@DisplayName("V�rification si la valeur est positive et enti�re")
	public void test__GetSignePositifReel() {
		assertEquals(Manipulation.getSigne(12.85), "+ 12.85");
	}
	
	@Test
	@DisplayName("V�rification si la valeur est positive, r�el et se termine par z�ro")
	public void test__GetSignePositifReelZero() {
		assertEquals(Manipulation.getSigne(10.4400), "+ 10.44");
	}
	
	@Test
	@DisplayName("V�rification si la valeur est positive et enti�re")
	public void test__GetSignePositifEntier() {
		assertEquals(Manipulation.getSigne(17), "+ 17");
	}
	
	@Test
	@DisplayName("V�rification si la valeur est positive, enti�re et se termine par z�ro")
	public void test__GetSignePositifEntierZero() {
		assertEquals(Manipulation.getSigne(79.000), "+ 79");
	}
	
	@Test
	@DisplayName("V�rification si la valeur est un r�el")
	public void test__GererValeurReel() {
		assertEquals(Manipulation.gererValeurEntiere(88.85), "88.85");
	}
	
	@Test
	@DisplayName("V�rification si la valeur est un r�el mais suivi d'au moins un 0")
	public void test__GererValeurReelSuiviZero() {
		assertEquals(Manipulation.gererValeurEntiere(125.0500), "125.05");
	}
	
	@Test
	@DisplayName("V�rification si la valeur est un entier")
	public void test__GererValeurEntier() {
		assertEquals(Manipulation.gererValeurEntiere(9), "9");
	}
	
	@Test
	@DisplayName("V�rification si la valeur est un entier mais suivi d'au moins un 0")
	public void test__GererValeurEntierSuiviZero() {
		assertEquals(Manipulation.gererValeurEntiere(34.000), "34");
	}
	
	@Test
	@DisplayName("V�rification si l'on transforme bien un entier en cha�ne de caract�re")
	public void test__ToString() {
		assertEquals(Manipulation.toString(15.97), "15.97");
	}
	
	@Test
	@DisplayName("V�rification que l'on ne r�cup�re pas les deux derniers caract�res")
	public void test__Sub2LastChar() {
		assertEquals(Manipulation.sub2LastChar("Moto"), "Mo");
	}

}
