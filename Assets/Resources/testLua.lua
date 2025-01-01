
local helpers = require ("Assets/Resources/commands.lua")
--require "dialogueMachine"

local t = helpers.t
local o = helpers.o

t "Please Press Continue" 

local result = o { "Yes", "No" }

if result == "Yes" then
    helpers.yesResponse()
else
    helpers.noResponse()
end

t "end"

