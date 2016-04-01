import java.util.*;
import java.math.*;
import static java.lang.Math.*;

public class SegmentsAndPoints {
	class IntPair  implements Comparable<IntPair>{
		final int l;
		final int r;
		IntPair(int l, int r) {this.l=l;this.r=r;}

		public int compareTo(IntPair other) {
			return r == other.r ? l - other.l : r - other.r;
		}

	}
	public String isPossible(int[] p, int[] l, int[] r) {
		int n = p.length;
		Arrays.sort(p);

		ArrayList<IntPair> segments = new ArrayList<IntPair>();
		for (int i = 0; i < n; i++) {
			segments.add(new IntPair(l[i], r[i]));
		}

		Collections.sort(segments);

		for (int i = 0; i < n; i++) {
			boolean found = false;

			for (int k = 0; k < segments.size(); k++) {
				IntPair s = segments.get(k);
				if(p[i] >= s.l && p[i] <= s.r) {
					found = true;
					segments.remove(k);
					break;
				}
			}
			if (!found) return "Impossible";
		}

		return "Possible";
	}
}
