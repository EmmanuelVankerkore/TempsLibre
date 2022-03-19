package entities;

import exceptions.RetirerDepasserSeuil;
import interfaces.ICompteASeuil;

public class CompteASeuil extends Compte implements ICompteASeuil {
	
	Double seuil;
	
	public CompteASeuil() {
		super();
		setSeuil(100.00);
		
	}
	
	public CompteASeuil(Double montant) {
		super(montant);
		setSeuil(100.00);
	}

	public Double getSeuil() {
		return seuil;
	}

	public void setSeuil(Double seuil) {
		this.seuil = seuil;
	}

	public void afficher() {
		System.out.print("Le numero de compte " + getNumero() + " est au solde de " + getMontant());
		System.out.println(" € avec un seuil à " + getSeuil() + " €");
	}
	
	public void retirer(Double montant) throws RetirerDepasserSeuil{
		if (getMontant() - montant >= getSeuil()) {
			/*
			System.out.println("solde actuel : " + getMontant());
			System.out.println("montant : " + montant);
			System.out.println("Soustraction des deux : " + (getMontant() - montant));
			System.out.println("Seuil : " + getSeuil());*/
			retirer(montant);
		} else {
			throw new RetirerDepasserSeuil();
		}
	}
}
