package entities;

public class DroiteAffine {
	
	String name;
	Double coef;
	Double constante;
	
	public DroiteAffine(String nom, Double a, Double b) {
		setName(nom);
		setCoef(a);
		setConstante(b);
	}
	
	public DroiteAffine(String nom, Point2D a, Point2D b) {
		setName(nom);
		if (a.getX() <= b.getX()) {
			setCoef((b.getY()-a.getY())/(b.getX()-a.getX()));
			setConstante(a.getY()-(a.getX()*(b.getY()-a.getY())/(b.getX()-a.getX())));
		} else {
			setCoef((a.getY()-b.getY())/(a.getX()-b.getX()));
			setConstante(a.getY()-(a.getX()*(a.getY()-b.getY())/(a.getX()-b.getX())));
		}
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Double getCoef() {
		return coef;
	}

	public void setCoef(Double coef) {
		this.coef = coef;
	}

	public Double getConstante() {
		return constante;
	}

	public void setConstante(Double constante) {
		this.constante = constante;
	}

	public void afficher() {
		if (getConstante() >= 0.0) {
			System.out.println("(" + getName() + ") : y = " + getCoef() + " x + " + getConstante());
		} else {
			System.out.println("(" + getName() + ") : y = " + getCoef() + " x - " + (-getConstante()));
		}	
	}
	
	public DroiteAffine getDroiteAffinePerpendiculaireFromPoint(Point2D point) {
		return new DroiteAffine(getName().concat("_2"), -1/getCoef(), point.getY() + (1/getCoef())*point.getX());
	}
	
	public String getNameIntersection(DroiteAffine d) {
		return "Intersection_".concat(getName()).concat("_").concat(d.getName());
	}
	
	public Point2D getPointIntersection(DroiteAffine droite) {
		return new Point2D(" ", 0.0, 0.0);
	}
}
