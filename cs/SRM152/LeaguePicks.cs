using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

public class LeaguePicks
{
	public int[] returnPicks(int position, int friends, int picks)
	{
		var cycle = friends*2;
		var completeCycles = picks/cycle + 2;
		var res = new List<int>();
		for(int i = 0; i < completeCycles; ++i){
			var val1 = i*cycle+position;
			var val2 = i*cycle+(cycle-position+1);
			if(val1<=picks)res.Add(val1);
			if(val2<=picks)res.Add(val2);
		}
		return res.ToArray();
	}


}
//Powered by [KawigiEdit] 2.0!
