import java.util.*;
import java.math.*;
import static java.lang.Math.*;

public class RectangularGrid {
	
	public long countRectangles(int width, int height) {
		long a[][] = new long[1001][1001];
		for (int i = 1; i <= 1000; i++) {
			a[1][i] = (i * (i-1)) / 2;
			a[i][1] = a[1][i];
		}
		for (int n = 2; n <= 1000; n++) {
			for (int m = n; m <= 1000; m++) {
				long r = 2 * a[n][m - 1];
				r -= a[n][m - 2];
				r += (n * (n + 1)) / 2;
				r -= (m == n) ? 1 : 0;
				a[n][m] = r;
				a[m][n] = r;
			}
		}
		return a[width][height];
	}
}
