
local helpers = require ("Assets/Resources/Lua/commands.lua")
local dm = require ("Assets/Resources/Lua/DialogueManager.lua")

local t = helpers.t
local o = helpers.o

local addNode = function(...) dm:addNode(...) end
local jump = function(...) dm:jump(...) end

local firstTime = true

addNode 
("start", function()
    if firstTime then
        print "lua script start"
        firstTime = false
    end
    t "Start: Please press continue button"
    jump "continue"
end)

addNode 
("continue", function()
    t "Do you want to continue?"
    local result = o { "Yes", "No" }
    if result == "Yes" then
        jump "yesResponse"
    else
        jump "noResponse"
    end
end)

addNode 
("yesResponse", function()
    t "You chose Yes!"
    t "Goodbye!"
    t "end"
    jump "returnStart"
end)

addNode 
("noResponse", function()
    t "You chose No!"
    t "Goodbye!"
    t "end"
    jump "returnStart"
end)

addNode
("returnStart", function()
    t "return to start"
    jump "start"
end)

dm:start()
