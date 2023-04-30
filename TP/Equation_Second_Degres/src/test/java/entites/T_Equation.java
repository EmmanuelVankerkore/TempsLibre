package entites;

import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.Test;
import org.junit.jupiter.api.DisplayName;

public class T_Equation {
	
	@Test
	@DisplayName("On test si l'utilisateur essai d'entrer une valeur nulle pour A")
	public void test__AfficherEquationImpossibleValeurANulle() {
		try {
			Equation e = new Equation(0, 80, -52);
		} catch (Exception e1) {
			System.out.println(e1.getMessage());
		}
	}
	
	@Test
	@DisplayName("Tous les param�tres sont des entiers positifs")
	public void test__AfficherEquationEntiersAllPositive() throws Exception {
		Equation e = new Equation(8, 12, 2);
		assertEquals(e.getFormule(), "Y = 8 X� + 12 X + 2");
	}

	@Test
	@DisplayName("Tous les param�tres sont des entiers n�gatifs")
	public void test__AfficherEquationEntiersAllN�gatifs() throws Exception {
		Equation e = new Equation(-4, -1, -3);
		assertEquals(e.getFormule(), "Y = -4 X� - 1 X - 3");
	}
	
	@Test
	@DisplayName("Tous les param�tres sont des r�els positifs")
	public void test__AfficherEquationReelsAllPositive() throws Exception {
		Equation e = new Equation(8.12, 12.02, 2.84);
		assertEquals(e.getFormule(), "Y = 8.12 X� + 12.02 X + 2.84");
	}

	@Test
	@DisplayName("Tous les param�tres sont des r�els n�gatifs")
	public void test__AfficherEquationReelsAllN�gatifs() throws Exception {
		Equation e = new Equation(-4.41, -1.56, -3.37);
		assertEquals(e.getFormule(), "Y = -4.41 X� - 1.56 X - 3.37");
	}

}
