import org.junit.Test;
import static org.junit.Assert.*;

public class SegmentsAndPointsTest {

	@Test(timeout=2000)
	public void systemtest() {
		int[] p = new int[] {163, -229, -158, 494, -24, 232, 445, 471, 58, 217, 192, 294, -272, 40, -91, 217, 417, -69, -81, -116, -27, 174, 114, 382, 137, 115, -39, -493, -338, -103, -323, 186, -476, -226, -36, 314, -397, 95, -238, 212, -225, 106, 96, 353, -473, -454, 197, -292, -380, 148, -273, 154, -395, 395, 281, -170, -143, -306, -247, -3, -234, 354, 305, -405, 6, 345, 341, -251, -76, 290, 78, -390, 315, 434, 0, -327, -245, -319, -462, 407, -248, 380, 451, 383, 182, 166, -306, -83, 136, 329, -79, 108, 78, 183, -24, 186, -409, -304, 113, 90};
		int[] l = new int[] {-372, 295, -43, 286, 402, 455, -219, 180, -52, -485, -189, -29, -182, 6, 101, 192, -424, 403, -497, 196, 245, 235, 29, 399, 203, -327, 181, 147, -391, -472, 494, -276, -129, -412, -186, -90, -271, -280, 467, -93, -401, -380, -47, -171, -387, -62, 459, -300, -48, 157, 213, -294, -332, 392, 18, -335, -342, 120, -399, -109, -478, 293, 427, 70, 213, 285, 401, -261, 327, -419, 291, 235, -235, 485, 458, -462, -382, -371, 147, 392, -202, 185, 436, -277, -273, 429, -187, 55, -194, 57, 438, 428, 418, -199, -495, 179, 416, -335, 446, 467};
		int[] r = new int[] {154, 437, 327, 343, 479, 468, 68, 392, -14, -9, 361, 288, 388, 39, 449, 202, 170, 445, -241, 394, 255, 269, 89, 483, 347, 116, 222, 241, 298, -82, 495, 358, -101, 499, -165, -37, 236, -158, 484, 181, -385, 89, -28, 314, 66, 353, 483, -285, 390, 494, 312, 430, -240, 499, 235, -46, -185, 380, -73, 223, 261, 353, 468, 241, 366, 487, 419, 141, 411, 453, 326, 257, -162, 485, 484, 284, -148, 210, 456, 393, 356, 235, 487, -253, 147, 450, 360, 253, -137, 297, 445, 456, 420, -81, -109, 186, 445, -90, 462, 492};
		assertEquals("Impossible", new SegmentsAndPoints().isPossible(p, l, r));
	}

	@Test(timeout=2000)
	public void test0() {
		int[] p = new int[] {1, 2};
		int[] l = new int[] {0, 0};
		int[] r = new int[] {1, 3};
		assertEquals("Possible", new SegmentsAndPoints().isPossible(p, l, r));
	}
	
	@Test(timeout=2000)
	public void test1() {
		int[] p = new int[] {0};
		int[] l = new int[] {2};
		int[] r = new int[] {3};
		assertEquals("Impossible", new SegmentsAndPoints().isPossible(p, l, r));
	}
	
	@Test(timeout=2000)
	public void test2() {
		int[] p = new int[] {0, 1, 2};
		int[] l = new int[] {0, 0, 1};
		int[] r = new int[] {1, 2, 1};
		assertEquals("Possible", new SegmentsAndPoints().isPossible(p, l, r));
	}
	
	@Test(timeout=2000)
	public void test3() {
		int[] p = new int[] {0, 1};
		int[] l = new int[] {-1, 0};
		int[] r = new int[] {0, 0};
		assertEquals("Impossible", new SegmentsAndPoints().isPossible(p, l, r));
	}
	
	@Test(timeout=2000)
	public void test4() {
		int[] p = new int[] {434, 63, 241, 418, -380, -46, 397, -205, -262, -282, 260, -106, -389, -286, 422, -75, 127, 382, 52, -383};
		int[] l = new int[] {-447, -226, -411, 287, -83, -228, -390, 358, 422, 395, -461, -112, 49, 75, -160, -152, 372, -447, -337, -362};
		int[] r = new int[] {-102, 348, -70, 466, 168, -61, -389, 469, 433, 471, -75, -41, 52, 236, 299, -48, 383, -353, 346, -217};
		assertEquals("Possible", new SegmentsAndPoints().isPossible(p, l, r));
	}
}
