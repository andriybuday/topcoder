import java.util.*;

public class PowerOutage {

	class IntPair {
		final int x;
		final int y;
		final int l;
		IntPair(int x, int y, int l) {this.x=x;this.y=y;this.l=l;}
	}

	public int getMax(int node, ArrayList<ArrayList<IntPair>> m){
		if(m.get(node).size() == 0){
			return 0;
		}
		int max = 0;
		for (int i = 0; i < m.get(node).size(); i++) {
			IntPair intPair = m.get(node).get(i);
			int estLeaf = intPair.l + getMax(intPair.y, m);
			if(estLeaf > max) {
				max = estLeaf;
			}
		}
		return max;
	}

	public int estimateTimeOut(int[] fromJunction, int[] toJunction, int[] ductLength) {
		ArrayList<ArrayList<IntPair>> m = GetM(fromJunction, toJunction, ductLength);
		int sum = 0;
		for (int i = 0; i < ductLength.length; i++) {
			sum += ductLength[i];
		}
		return 2 * sum - getMax(0, m);
	}

	private ArrayList<ArrayList<IntPair>> GetM(int[] fromJunction, int[] toJunction, int[] ductLength) {
		ArrayList<ArrayList<IntPair>> m = new ArrayList<ArrayList<IntPair>>();
		for (int i = 0; i < 52; i++) {
			m.add(new ArrayList<IntPair>());
		}

		for (int i = 0; i < fromJunction.length; i++) {
			int node = fromJunction[i];
			if(m.get(node).size() == 0) {
				for (int j = 0; j < fromJunction.length; j++) {
					if (node == fromJunction[j]) {
						m.get(node).add(new IntPair(fromJunction[j], toJunction[j], ductLength[j]));
					}
				}
			}
		}
		return m;
	}
}
