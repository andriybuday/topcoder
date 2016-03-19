import java.util.*;
import java.math.*;
import static java.lang.Math.*;

public class DoubleWeights {


	private ArrayList<ArrayList<IntPair>> GetM(String[] weights, String[] weights2) {
		int n = weights.length;
		ArrayList<ArrayList<IntPair>> m = new ArrayList<ArrayList<IntPair>>();
		for (int i = 0; i < n+1; i++) {
			m.add(new ArrayList<IntPair>());
		}
		for (int i = 0; i < n; i++) {
			for (int j = 0; j < weights[i].length(); j++) {
				char c = weights[i].charAt(j);
				char c2 = weights2[i].charAt(j);
				if(c != '.' && c2 != '.'){
					int w = (int)(c - '0');
					int w2 = (int)(c2 - '0');
					m.get(i).add(new IntPair(i, j, w, w2, w * w2));
				}
			}
		}
		return m;
	}

	int globalBest = Integer.MAX_VALUE;
	public int minimalCost(String[] weight1, String[] weight2) {
		ArrayList<ArrayList<IntPair>> w = GetM(weight1, weight2);

		List<Integer> currentPath = new ArrayList<Integer>();
		currentPath.add(0);
		IntPair min = getMin(0, w, currentPath, Integer.MAX_VALUE);

		return min.wRes;
	}

	class IntPair {
		final int x;
		final int y;
		final int w1;
		final int w2;
		final int wRes;
		IntPair(int x, int y, int w1, int w2, int wRes) {this.x=x;this.y=y;this.w1 =w1;this.w2=w2;this.wRes=wRes;}
	}

	public IntPair getMin(int node, ArrayList<ArrayList<IntPair>> m, List<Integer> currentPath, int currentBest){
		if(node == 1) {
			if(currentBest < globalBest) {
				globalBest = currentBest;
			}
			return new IntPair(node, 1, 0, 0, 0);
		}
		if(m.get(node).size() == 0 || currentPath.size() > 21 ||
						(currentBest > globalBest)){
			return new IntPair(node, 1, 0, 0, -1);
		}
		int min = Integer.MAX_VALUE;
		int min1 = Integer.MAX_VALUE;
		int min2 = Integer.MAX_VALUE;
		boolean pathFound = false;
		for (int i = 0; i < m.get(node).size(); i++) {
			IntPair intPair = m.get(node).get(i);
			if(!currentPath.contains(intPair.y)){
				ArrayList<Integer> newPath = new ArrayList<Integer>(currentPath);
				newPath.add(intPair.y);
				IntPair leafMin = getMin(intPair.y, m, newPath, min);
				if(leafMin.wRes != -1) {
					int estLeaf = (intPair.w1 + leafMin.w1) * (intPair.w2 + leafMin.w2);
					if(estLeaf < min) {
						min1 = (intPair.w1 + leafMin.w1);
						min2 = (intPair.w2 + leafMin.w2);
						min = estLeaf;
						pathFound = true;
//						if(min > currentBest*2){
//							return new IntPair(node, 1, 0, 0, -1);
//						}
					}
				}
			}
		}
		return pathFound ? new IntPair(node, 1, min1, min2, min) :new IntPair(node, 1, 0, 0, -1);
	}
}
