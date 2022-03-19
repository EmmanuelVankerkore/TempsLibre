package interfaces;

import exceptions.RetirerDepasserSeuil;

public interface ICompteASeuil {

	public Double getSeuil();
	public void setSeuil(Double seuil);
	public void retirer(Double montant) throws RetirerDepasserSeuil;
}
