package interfaces;

public interface ICompteASeuil {

	public double getSeuil();
	public void setSeuil(Double seuil);
	public void retirerAvecRespectDuSeuil(Double montant);
}
