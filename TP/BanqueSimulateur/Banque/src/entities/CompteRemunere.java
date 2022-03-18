package entities;

public class CompteRemunere extends Compte{
	
	Double taux;
	
	public CompteRemunere() {
		super();
		setTaux(0.015);
	}
	
	public CompteRemunere(Double montant) {
		super(montant);
		setTaux(0.015);
	}

	public Double getTaux() {
		return taux;
	}

	public void setTaux(Double taux) {
		this.taux = taux;
	}
	
	public void afficher() {
		System.out.print("Le numero de compte " + getNumero() + " est au solde de " + getMontant());
		System.out.println(" € avec un taux d'intérêt à " + getTaux() + "%");
	}
	
	public double calculerInteret() {
		return getTaux()*getMontant();
	}
	
	public void verserInteret() {
		ajouter(calculerInteret());
	}
}
