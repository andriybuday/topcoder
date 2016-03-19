import org.junit.Test;
import static org.junit.Assert.*;

public class DoubleWeightsTest {
	
	@Test(timeout=2000)
	public void test0() {
		String[] weight1 = new String[] {"..14",
 "..94",
 "19..",
 "44.."};
		String[] weight2 = new String[] {"..94",
 "..14",
 "91..",
 "44.."};
		assertEquals(64, new DoubleWeights().minimalCost(weight1, weight2));
	}
	
	@Test(timeout=2000)
	public void test1() {
		String[] weight1 = new String[] {"..14",
 "..14",
 "11..",
 "44.."};
		String[] weight2 = new String[] {"..94",
 "..94",
 "99..",
 "44.."};
		assertEquals(36, new DoubleWeights().minimalCost(weight1, weight2));
	}
	
	@Test(timeout=2000)
	public void test2() {
		String[] weight1 = new String[] {"..",
 ".."};
		String[] weight2 = new String[] {"..",
 ".."};
		assertEquals(-1, new DoubleWeights().minimalCost(weight1, weight2));
	}
	
	@Test(timeout=2000)
	public void test3() {
		String[] weight1 = new String[] {".....9",
 "..9...",
 ".9.9..",
 "..9.9.",
 "...9.9",
 "9...9."};
		String[] weight2 = new String[] {".....9",
 "..9...",
 ".9.9..",
 "..9.9.",
 "...9.9",
 "9...9."};
		assertEquals(2025, new DoubleWeights().minimalCost(weight1, weight2));
	}
	
	@Test(timeout=2000)
	public void test4() {
		String[] weight1 = new String[] {".4...1",
 "4.1...",
 ".1.1..",
 "..1.1.",
 "...1.1",
 "1...1."};
		String[] weight2 = new String[] {".4...1",
 "4.1...",
 ".1.1..",
 "..1.1.",
 "...1.1",
 "1...1."};
		assertEquals(16, new DoubleWeights().minimalCost(weight1, weight2));
	}

	@Test(timeout=2000)
	public void test5() {
		String[] weight1 = new String[] {".7745762298589865231", "7.917985933724446171", "79.98468554783198485", "419.6754527284586726", "5786.445183531375867", "79474.43998929523755", "686544.3368796584333", "2584533.413717594127", "29551934.96746422171", "935289619.2161239368", "8347388362.848752978", "57725977718.23589176", "828832914642.9359347", "9434196761839.871915", "84153555427538.76389", "649872892358577.1784", "5686534429299161.672", "21478731139139376.67", "378265327677418876.5", "1156753718867594275."};
		String[] weight2 = new String[] {".7745762298589865231", "7.917985933724446171", "79.98468554783198485", "419.6754527284586726", "5786.445183531375867", "79474.43998929523755", "686544.3368796584333", "2584533.413717594127", "29551934.96746422171", "935289619.2161239368", "8347388362.848752978", "57725977718.23589176", "828832914642.9359347", "9434196761839.871915", "84153555427538.76389", "649872892358577.1784", "5686534429299161.672", "21478731139139376.67", "378265327677418876.5", "1156753718867594275."};
		assertEquals(4, new DoubleWeights().minimalCost(weight1, weight2));
	}

	@Test(timeout=2000)
	public void test6() {
		String[] weight1 = new String[] {
						".5.2.2.8",
						"5.19.463",
						".1.13.47",
						"291.5.8.",
						"..35.253",
						"24..2.93",
						".64859.1",
						"837.331."};
		String[] weight2 = new String[] {
						".5.2.2.8",
						"5.19.463",
						".1.13.47",
						"291.5.8.",
						"..35.253",
						"24..2.93",
						".64859.1",
						"837.331."};
		assertEquals(16, new DoubleWeights().minimalCost(weight1, weight2));
	}


}
