local Score = require("sphere.screen.gameplay.CloudburstEngine.Score")

local CustomScore = Score:new()

CustomScore.passEdge = 0.420
CustomScore.missEdge = 0.500

CustomScore.timegates = {
	{
		time = 0.021,
		name = "MAX 100%"
	},
	{
		time = 0.060,
		name = "MAX 90%"
	},
	{
		time = 0.100,
		name = "MAX 80%"
	},
	{
		time = 0.140,
		name = "MAX 70%"
	},
	{
		time = 0.180,
		name = "MAX 60%"
	},
	{
		time = 0.220,
		name = "MAX 50%"
	},
	{
		time = 0.260,
		name = "MAX 40%"
	},
	{
		time = 0.300,
		name = "MAX 30%"
	},
	{
		time = 0.340,
		name = "MAX 20%"
	},
	{
		time = 0.380,
		name = "MAX 10%"
	},
	{
		time = 0.420,
		name = "MAX 1%"
	},
	{
		time = 0.500,
		name = "BREAK"
	}
}

Score.grades = {
	{time = 0.001,	name = "auto"	},
	{time = 0.002,	name = "cheater"},
	{time = 0.004,	name = ">_<"	},
	{time = 0.006,	name = "wtf?"	},
	{time = 0.008,	name = "ET"		},
	{time = 0.010,	name = "$$$"	},
	{time = 0.012,	name = "SS"		},
	{time = 0.016,	name = "S++"	},
	{time = 0.020,	name = "S+"		},
	{time = 0.024,	name = "S"		},
	{time = 0.028,	name = "A+"		},
	{time = 0.032,	name = "A"		},
	{time = 0.048,	name = "B"		},
	{time = 0.98,	name = "E"		},
	{name = "F"},
}

return CustomScore
