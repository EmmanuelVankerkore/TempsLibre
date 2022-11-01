package resultats;

public class Record {
	
	int idRecord;
	Double tailleSegmentUnitaire;
	int nombreSegments;
	Double estimationPi;
	
	static int id = 0;
	
	public Record(Double taille, int nombre) {
		this.idRecord = id;
		setTailleSegmentUnitaire(taille);
		setNombreSegments(nombre);
		this.estimationPi = getTailleSegmentUnitaire() * getNombreSegments();
		id++;
	}

	public int getIdRecord() {
		return idRecord;
	}

	public Double getTailleSegmentUnitaire() {
		return tailleSegmentUnitaire;
	}

	public void setTailleSegmentUnitaire(Double tailleSegmentUnitaire) {
		this.tailleSegmentUnitaire = tailleSegmentUnitaire;
	}

	public int getNombreSegments() {
		return nombreSegments;
	}

	public void setNombreSegments(int nombreSegments) {
		this.nombreSegments = nombreSegments;
	}

	public Double getEstimationPi() {
		return estimationPi;
	}

	public static int getId() {
		return id;
	}
	
	public void afficher() {
		System.out.println("id : " + getIdRecord());
		System.out.println("   taille     : " + getTailleSegmentUnitaire());
		System.out.println("   nb         : " + getNombreSegments());
		System.out.println("   estimation : " + getEstimationPi());
		
	}
}
