local aquafonts		= require("aqua.assets.fonts")
local TextFrame		= require("aqua.graphics.TextFrame")
local Class			= require("aqua.util.Class")
local spherefonts	= require("sphere.assets.fonts")

local JudgeTable = Class:new()

JudgeTable.rowHeight = 0.06
JudgeTable.x = 0.1
JudgeTable.y = 0.125
JudgeTable.w = 0.25
JudgeTable.load = function(self)
	self.judgeNames = {}
	self.judgeGates = {}
	self.judgeValues = {}
	
	self.row = 1
	self:addHeader()
	for i = 1, #self.score.timegates do
		self.judgeNames[self.row] = self:getJudgeNameText(self.score.timegates[i].name, self.row)
		self.judgeNames[self.row]:reload()
		
		self.judgeGates[self.row] = self:getJudgeGateText(self.score.timegates[i].time * 1000, self.row)
		self.judgeGates[self.row]:reload()
		
		self.judgeValues[self.row] = self:getJudgeValueText(self.score.judges[i], self.row)
		self.judgeValues[self.row]:reload()
		
		self.row = self.row + 1
	end
end

JudgeTable.compute = function(self)

end

JudgeTable.reload = function(self)
	for i = 1, #self.judgeNames do
		self.judgeNames[i]:reload()
		self.judgeGates[i]:reload()
		self.judgeValues[i]:reload()
	end
end

JudgeTable.draw = function(self)
	for i = 1, #self.judgeNames do
		self.judgeNames[i]:draw()
		self.judgeGates[i]:draw()
		self.judgeValues[i]:draw()
	end
end

JudgeTable.getJudgeNameText = function(self, text, row)
	return TextFrame:new({
		text = text,
		x = self.x + 0.03,
		y = self.y + (row - 1) * self.rowHeight,
		w = self.w,
		h = self.rowHeight,
		cs = self.cs,
		limit = self.w,
		align = {x = "left", y = "center"},
		color = {255, 255, 255, 255},
		font = aquafonts.getFont(spherefonts.NotoSansRegular, 28)
	})
end

JudgeTable.getJudgeGateText = function(self, text, row)
	return TextFrame:new({
		text = text,
		x = 0,
		y = self.y + (row - 1) * self.rowHeight,
		w = self.x,
		h = self.rowHeight,
		cs = self.cs,
		limit = self.x,
		align = {x = "right", y = "center"},
		color = {255, 255, 255, 255},
		font = aquafonts.getFont(spherefonts.NotoSansRegular, 28)
	})
end

JudgeTable.getJudgeValueText = function(self, text, row)
	return TextFrame:new({
		text = (text or 0),
		x = self.x,
		y = self.y + (row - 1) * self.rowHeight,
		w = self.w,
		h = self.rowHeight,
		cs = self.cs,
		limit = self.w,
		align = {x = "right", y = "center"},
		color = {255, 255, 255, 255},
		font = aquafonts.getFont(spherefonts.NotoSansRegular, 28)
	})
end

JudgeTable.addHeader = function(self)
	self.judgeNames[self.row] = self:getJudgeNameText("grade", self.row)
	self.judgeNames[self.row]:reload()
	
	self.judgeGates[self.row] = self:getJudgeGateText("timegate", self.row)
	self.judgeGates[self.row]:reload()
	
	self.judgeValues[self.row] = self:getJudgeValueText("count", self.row)
	self.judgeValues[self.row]:reload()
	
	self.row = self.row + 1
end

return JudgeTable
