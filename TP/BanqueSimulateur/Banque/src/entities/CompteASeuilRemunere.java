package entities;

import interfaces.ICompteASeuil;

public class CompteASeuilRemunere extends CompteRemunere implements ICompteASeuil {

	Double seuil;
	
	public CompteASeuilRemunere() {
		super(1000.00);
		setSeuil(100.00);
	}
	
	public Double getSeuil() {
		return seuil;
	}

	public void setSeuil(Double seuil) {
		this.seuil = seuil;
	}
	
	public void retirer(Double montant) {
		if (getMontant() - montant >= getSeuil()) {
			retirer(montant);
		}
	}
	
	public void afficher() {
		System.out.println("N° de compte : " + getNumero());
		System.out.println("   Solde : " + getMontant());
		System.out.println("   Seuil : " + getSeuil());
		System.out.println("   Taux : " + getTaux());
	}
}
