import java.util.*;
import java.math.*;
import static java.lang.Math.*;

public class BridgeCrossing {
	
	public int minTime(int[] times) {
		ArrayList<Integer> t = new ArrayList<Integer>();
		for (int i = 0; i < times.length; i++) {
			t.add(times[i]);
		}
		return go(t, new ArrayList<Integer>());
	}
	// HORRIBLE !!!!
	public int go(List<Integer> t, List<Integer> l) {
		if(t.size() == 0)return 0;
		if(t.size() == 1){
			return t.get(0);
		}
		if(t.size() == 2){
			return Math.max(t.get(0), t.get(1));
		}
		if(t.size() == 3){
			int sum = sum(t);
			if(l.size() == 0)
				return sum;
			else {
				int other =  Math.max(t.get(0), Math.max(t.get(1), t.get(2))) + 2 * l.get(0);
				return Math.min(other, sum);
			}
		}
		Collections.sort(t);
		// Case 1
		ArrayList<Integer> tCopy1 = new ArrayList<Integer>(t);
		List<Integer> newT1 = tCopy1.subList(1, tCopy1.size()-1);
		List<Integer> newL1 = new ArrayList<Integer>(l);
		newL1.add(tCopy1.get(0));
		Integer maxMoved1 = tCopy1.get(tCopy1.size()-1);
		newL1.add(maxMoved1);
		Collections.sort(newL1);
		Integer moveBack1 = newL1.get(0);
		newL1.remove(0);
		newT1.add(moveBack1);
		int minCase1 = moveBack1 + maxMoved1 + go(newT1, newL1);

		// Case 2
		ArrayList<Integer> tCopy2 = new ArrayList<Integer>(t);
		List<Integer> newT2 = tCopy2.subList(2, t.size());
		List<Integer> newL2 = new ArrayList<Integer>(l);
		newL2.add(tCopy2.get(0));
		Integer maxMoved2 = tCopy2.get(1);
		newL2.add(0,maxMoved2);
		Collections.sort(newL2);
		Integer moveBack2 = newL2.get(0);
		newL2.remove(0);
		newT2.add(moveBack2);
		int minCase2 = moveBack2 + maxMoved2 + go(newT2, newL2);

		// Case 3
		ArrayList<Integer> tCopy3 = new ArrayList<Integer>(t);
		List<Integer> newT3 = tCopy3.subList(0, t.size()-2);
		List<Integer> newL3 = new ArrayList<Integer>(l);
		newL3.add(tCopy3.get(tCopy3.size()-2));
		Integer maxMoved3 = tCopy3.get(tCopy3.size()-1);
		newL3.add(0,maxMoved3);
		Collections.sort(newL3);
		Integer moveBack3 = newL3.get(0);
		newL3.remove(0);
		newT3.add(moveBack3);
		int minCase3 = moveBack3 + maxMoved3 + go(newT3, newL3);

		return Math.min(minCase1, Math.min(minCase2, minCase3));
	}
	public int sum(List<Integer> a){
		int sum = 0;
		for (int i = 0; i < a.size(); i++) {
			sum += a.get(i);
		}
		return sum;
	}
}
