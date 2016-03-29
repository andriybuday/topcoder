import java.lang.reflect.Array;
import java.util.*;
import java.math.*;
import static java.lang.Math.*;

public class SegmentsAndPoints {
	class IntPair  implements Comparable<IntPair>{
		final int l;
		final int r;
		final int p;
		IntPair(int x, int y, int l) {this.l=x;this.r=y;this.p=l;}

		public int compareTo(IntPair other) {
			return l - other.l;
		}

	}
	public String isPossible(int[] p, int[] l, int[] r) {
		int n = p.length;
		Arrays.sort(p);

		ArrayList<IntPair> segments = new ArrayList<IntPair>();
		for (int i = 0; i < n; i++) {
			segments.add(new IntPair(l[i], r[i], 0));
		}

		Collections.sort(segments);

		int j = 0;
		for (int i = 0; i < n; i++) {
			IntPair s = segments.get(j);
			while(j < n && (p[i] < s.l || p[i] > s.r)) {
				j++;
				if(j < n) s = segments.get(j);
			}
		}

		return (j >= n) ? "Impossible" : "Possible";
	}
}
