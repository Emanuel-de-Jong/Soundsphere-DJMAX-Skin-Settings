local Score = require("sphere.screen.gameplay.CloudburstEngine.Score")

local CustomScore = Score:new()

CustomScore.passEdge = 0.220
CustomScore.missEdge = 0.260

CustomScore.timegates = {
	{
		time = 0.018,
		name = "MAX 100%"
	},
	{
		time = 0.040,
		name = "MAX 90%",
		nameLate = "SLOW 90%",
		nameEarly = "FAST 90%"
	},
	{
		time = 0.060,
		name = "MAX 80%",
		nameLate = "SLOW 80%",
		nameEarly = "FAST 80%"
	},
	{
		time = 0.080,
		name = "MAX 70%",
		nameLate = "SLOW 70%",
		nameEarly = "FAST 70%"
	},
	{
		time = 0.100,
		name = "MAX 60%",
		nameLate = "SLOW 60%",
		nameEarly = "FAST 60%"
	},
	{
		time = 0.120,
		name = "MAX 50%",
		nameLate = "SLOW 50%",
		nameEarly = "FAST 50%"
	},
	{
		time = 0.140,
		name = "MAX 40%",
		nameLate = "SLOW 40%",
		nameEarly = "FAST 40%"
	},
	{
		time = 0.160,
		name = "MAX 30%",
		nameLate = "SLOW 30%",
		nameEarly = "FAST 30%"
	},
	{
		time = 0.180,
		name = "MAX 20%",
		nameLate = "SLOW 20%",
		nameEarly = "FAST 20%"
	},
	{
		time = 0.200,
		name = "MAX 10%",
		nameLate = "SLOW 10%",
		nameEarly = "FAST 10%"
	},
	{
		time = 0.220,
		name = "MAX 1%",
		nameLate = "SLOW 1%",
		nameEarly = "FAST 1%"
	},
	{
		time = 0.260,
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
