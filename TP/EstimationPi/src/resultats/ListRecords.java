package resultats;

import java.util.ArrayList;
//import java.util.ArrayList;
import java.util.List;

public class ListRecords {
	
	List<Record> listeRecords;
	
	public ListRecords() {
		//setListeRecords(null);
		this.listeRecords = new ArrayList<Record>();
	}

	public List<Record> getListeRecords() {
		return listeRecords;
	}

	/*
	public void setListeRecords(List<Record> listeRecords) {
		this.listeRecords = listeRecords;
	}
	*/

	public void ajouterRecord(Record rec) {
		//setListeRecords(getListeRecords().add(rec)); // setListeRecords(List<Record>) in the type ListRecords is not applicable 
														// for the arguments (boolean)

		/*
		List<Record> lr = new ArrayList<Record>() ;
		lr.add(rec);
		setListeRecords(lr);
		*/
		
		this.listeRecords.add(rec);
		
	}
	
	public void afficher() {
		for (Record record : listeRecords) {
			record.afficher();
		}
	}
}
