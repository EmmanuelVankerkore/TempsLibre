package exceptions;

public class RetirerDepasserSeuil extends Exception {

	private static final long serialVersionIUD = 1L; 
	
	public RetirerDepasserSeuil() {
		super("Le retrait dépasse la limite du seuil autorisé");
	}
	
	
}
