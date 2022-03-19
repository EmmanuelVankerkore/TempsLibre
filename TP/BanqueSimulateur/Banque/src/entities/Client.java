package entities;

import java.util.ArrayList;

public class Client {

	static Integer compteur = 10000;
	String Nom;
	String Prenom;
	Integer Age;
	Integer NumeroClient;
	ArrayList<Compte> comptes;	
	
	public Client(String nom, String prenom, Integer age) {
		setNumeroClient();
		setAge(age);
		setNom(nom);
		setPrenom(prenom);
		comptes = new ArrayList<Compte>(5);
		compteur++;
	}

	public String getNom() {
		return Nom;
	}

	public void setNom(String nom) {
		Nom = nom;
	}

	public String getPrenom() {
		return Prenom;
	}

	public void setPrenom(String prenom) {
		Prenom = prenom;
	}

	public Integer getAge() {
		return Age;
	}

	public void setAge(Integer age) {
		Age = age;
	}

	public Integer getNumeroClient() {
		return NumeroClient;
	}

	public void setNumeroClient() {
		NumeroClient = compteur;
	}
	
	public Integer nombreDeCompte() {
		return this.comptes.size();
	}
	
	/**
	 * Afficher un message indiquant le nombre de comptes en possession du client
	 */
	public void afficherNbComptes() {
		System.out.println(getNom() + " " + getPrenom() + " possède " + nombreDeCompte() + " compte(s).");
	}
	
	public void afficherInformationCompte(Integer numeroCompte) {
		for (Compte compte : comptes) {
			if (numeroCompte.equals(compte.getNumero())) {
				System.out.println("Le numéro de compte " + compte.getNumero() + " est au solde de " + compte.getMontant());
				break;
			}
		}
	}
	
	public void ajouterUnCompte(Compte compte) {
		if (nombreDeCompte() <= 4) {
			//if (compte.getClass().getName() == "entities.CompteRemunere") {
				//compte.vers;
				this.comptes.add(compte);
				System.out.println("Le compte " + compte.getNumero() + " a été ajouté avec succés.");
			//}
		} else {
			System.out.println("Impossible d'ajouter un compte car la limite est atteinte.");
		}
	}
	
	public void consulterTousMesComptes() {
		for (Compte compte : comptes) {
			System.out.println("Le solde du compte N° " + compte.getNumero() + " est de " + compte.getMontant() + " €.");
		}
	}
	
	public void transfertCompteAVersComteB(Compte compteADebiter, Compte compteACrediter) {
		double montant = compteADebiter.getMontant();
		compteADebiter.retirer(montant);
		compteACrediter.ajouter(montant);
	}
	
	public void transfertCompteAVersCompteBPartiel(Compte compteADebiter, Compte compteACrediter, Double montant) {
		if (montant <= compteADebiter.getMontant()) {
			compteADebiter.retirer(montant);
			compteACrediter.ajouter(montant);
		}
	}
	
	public void transfertEtSupprimeCompte(Compte compteAReception, Compte compteASupprimer) {
		transfertCompteAVersComteB(compteASupprimer, compteAReception);
		this.comptes.remove(compteASupprimer);
	}
	
	public void verserInteretSurMesCompteRemunere() {
		for (Compte compte : comptes) {
			if (compte.getClass().getName() == "entities.CompteRemunere") {
				((CompteRemunere) compte).verserInteret();
			} else if (compte.getClass().getName() == "entities.CompteASeuilRemunere") {
				((CompteASeuilRemunere) compte).verserInteret();
			}
		}
			
	}
}
