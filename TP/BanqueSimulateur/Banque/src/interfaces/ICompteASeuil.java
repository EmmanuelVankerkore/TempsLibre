package interfaces;

import exceptions.RetirerDepasserSeuil;

public interface ICompteASeuil {

	public Double getSeuil();
	public void setSeuil(Double seuil);
	public void retirer2(Double montant) throws RetirerDepasserSeuil;
}
