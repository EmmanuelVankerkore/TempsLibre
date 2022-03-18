package entities;

public class CompteASeuil extends Compte{
	
	double seuil;
	
	public CompteASeuil() {
		super();
		setSeuil(50);
		
	}
	
	public CompteASeuil(Double montant) {
		super(montant);
		setSeuil(50);
	}

	public double getSeuil() {
		return seuil;
	}

	public void setSeuil(double seuil) {
		this.seuil = seuil;
	}

	public void afficher() {
		System.out.print("Le numero de compte " + getNumero() + " est au solde de " + getMontant());
		System.out.println(" € avec un seuil à " + getSeuil() + " €");
	}
	
	public void retirerAvecRespectDuSeuil(Double montant) {
		if (getMontant() - montant >= getSeuil()) {
			retirer(montant);
		}
	}
}
