package entities;

public class Point2D {
	
	String nom;
	Double x;
	Double y;
	
	public Point2D(String nom, Double abcisse, Double ordonnee) {
		setNom(nom);
		setX(abcisse);
		setY(ordonnee);
	}

	public String getNom() {
		return nom;
	}

	public void setNom(String nom) {
		this.nom = nom;
	}

	public Double getX() {
		return x;
	}

	public void setX(Double x) {
		this.x = x;
	}

	public Double getY() {
		return y;
	}

	public void setY(Double y) {
		this.y = y;
	}

	public void afficher() {
		System.out.println(getNom() + " --> (" + getX() + " ; " + getY() + ")");
	}
}
