package entities;

import interfaces.ICompteASeuil;

public class CompteASeuil extends Compte implements ICompteASeuil {
	
	Double seuil;
	
	public CompteASeuil() {
		super();
		setSeuil(0.015);
		
	}
	
	public CompteASeuil(Double montant) {
		super(montant);
		setSeuil(0.015);
	}

	public double getSeuil() {
		return seuil;
	}

	public void setSeuil(Double seuil) {
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
