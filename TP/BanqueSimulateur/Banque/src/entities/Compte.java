package entities;

public class Compte {
	
	static Integer compteur = 1000;
	Integer Numero;
	Double Montant;
	
	public Compte() {
		this.setNumero();
		this.setMontant(0.00);
		compteur++;
	}
	
	public Compte(Double MontantInitial) {
		this.setNumero();
		this.setMontant(MontantInitial);
		compteur++;
	}

	public Integer getNumero() {
		return Numero;
	}

	public void setNumero() {
		Numero = compteur;
	}

	public Double getMontant() {
		return Montant;
	}

	private void setMontant(Double montant) {
		Montant = montant;
	}
	
	public void afficher() {
		System.out.println("=========");
		System.out.println("Numéro du compte : " + this.getNumero());
		System.out.println("Solde du compte : " + this.getMontant());
		System.out.println("=========");
	}
	
	public void ajouter(double unMontant) {
		this.setMontant(this.getMontant() + unMontant);
	}
	
	public void retirer(double unMontant) {
		this.setMontant(this.getMontant() - unMontant);
	}
}
